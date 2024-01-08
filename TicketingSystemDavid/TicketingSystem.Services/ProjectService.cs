using Microsoft.EntityFrameworkCore;
using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Project;
using TicketingSystem.Services.Models.Ticket;
using TicketingSystem.Services.Models.Message;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Data;

namespace TicketingSystem.Services
{
    public class ProjectService : IProjectService
    {
        private readonly TicketingSystemDbContext dbContext;

        public ProjectService(TicketingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(ProjectCreateModelServices model)
        {
            Project project = new Project();

            project.Name = model.Name;
            project.Description = model.Description;


            await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();
        }

        //public async Task<FindProjectsResultViewModelServices> AllAsync(FindProjectsRequestViewModelServices queryModel)
        //{
        //    IQueryable<Project> projectQuery = dbContext
        //                        .Projects
        //                        .Where(b => b.SoftDeleted == false)
        //                        .AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
        //    {
        //        string wildCard = $"%{queryModel.SearchString.ToLower()}%";

        //        projectQuery = projectQuery
        //            .Where(h => EF.Functions.Like(h.Name, wildCard) ||
        //                        EF.Functions.Like(h.Description, wildCard));
        //    }

        //    projectQuery = queryModel.ProjectSorting switch
        //    {
        //        ProjectSortServices.NameAsc => projectQuery
        //            .OrderBy(b => b.Name),
        //        ProjectSortServices.NameDesc => projectQuery
        //            .OrderByDescending(b => b.Name)
        //    };

        //    IEnumerable<ProjectAllViewModelServices> projects = await projectQuery
        //        .Skip((queryModel.CurrentPage - 1) * queryModel.ProjectsPerPage)
        //        .Take(queryModel.ProjectsPerPage)
        //        .Select(b => new ProjectAllViewModelServices
        //        {
        //            Id = b.Id,
        //            Name = b.Name,
        //            Description = b.Description,
        //            TicketCount = b.Tickets.Where(x => x.SoftDeleted == false).Count(),
        //        })
        //        .ToArrayAsync();

        //    int totalProjectsCount = projectQuery.Count();

        //    return new FindProjectsResultViewModelServices()
        //    {
        //        TotalProjectsCount = totalProjectsCount,
        //        Projects = projects
        //    };
        //}

        public async Task<FindProjectsResultModelServices> GetProjectsAsync(string searchTerm, string sortOrder, int page, int pageSize)
        {
            var query = dbContext.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            }

            int totalProjects = await query.CountAsync();

            query = sortOrder switch
            {
                "name_asc" => query.OrderBy(p => p.Name),
                "name_desc" => query.OrderByDescending(p => p.Name),
                _ => query
            };


            var projects = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            FindProjectsResultModelServices result = new FindProjectsResultModelServices();
            
            result.TotalProjectsCount = totalProjects;
            result.Projects = projects.Select(b => new ProjectViewModelServices
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                TicketCount = b.Tickets.Where(x => x.SoftDeleted == false).Count(),
            });

            return (result);
        }

        public async Task<ProjectDetailsModelServices> FillModel(ProjectDetailsModelServices model, int id)
        {
            Project project = await dbContext.Projects.Include(x => x.Tickets).FirstOrDefaultAsync(x => x.Id == id);

            model.Id = project.Id;
            model.Description = project.Description;
            model.IsDeleted = project.SoftDeleted;
            model.Tickets = project.Tickets.Select(x => new TicketDetailsModelServices
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Creator = x.CreatorEmail,
                Type = x.Type,
                State = x.State,
                Heading = x.Heading,
                Description = x.Description,
                Messages = x.Messages.Select(x => new MessageDetailsViewModelService
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Creator = x.CreatorEmail,
                    State = (MessageStateService)Enum.Parse(typeof(MessageStateService), x.State.ToString()),
                    Content = x.Content,
                    TicketId = x.TicketId,
                    SoftDeleted = x.SoftDeleted
                }).ToList(),
                IsDeleted = x.SoftDeleted
            }).ToList();
            model.Name = project.Name;

            return model;
        }

        public async Task<Project> FindProject(int id)
        {
            return await dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Delete(int id)
        {
            Project project = await dbContext.Projects.FindAsync(id);

            project.SoftDeleted = true;

            await dbContext.SaveChangesAsync();
        }
    }
}
