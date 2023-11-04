using Microsoft.EntityFrameworkCore;
using TicketingSystem.Data.Models;
using TicketingSystem.Data.Interfaces;
using TicketingSystem.Services.ViewModels.Project;
using TicketingSystem.Services.ViewModels.Project.Enums;
using TicketingSystem.Services.ViewModels.Ticket;
using TicketingSystem.Services.ViewModels.Message;

namespace TicketingSystem.Data
{
    public class ProjectServices : IProjectServices
    {
        private readonly TicketingSystemDbContext dbContext;

        public ProjectServices(TicketingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(CreateProjectViewModel model)
        {
            Project project = new Project();

            project.Name = model.Name;
            project.Description = model.Description;

            await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AllProjectsFilteredAndOrdered> AllAsync(ProjectAllQueryModel queryModel)
        {
            IQueryable<Project> projectQuery = this.dbContext
                                .Projects
                                .Where(b => b.IsDeleted == false)
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                projectQuery = projectQuery
                    .Where(h => EF.Functions.Like(h.Name, wildCard) ||
                                EF.Functions.Like(h.Description, wildCard));
            }

            projectQuery = queryModel.ProjectSorting switch
            {
                ProjectSortEnum.NameAsc => projectQuery
                    .OrderBy(b => b.Name),
                ProjectSortEnum.NameDesc => projectQuery
                    .OrderByDescending(b => b.Name)
            };

            IEnumerable<ProjectAllViewModel> projects = await projectQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.ProjectsPerPage)
                .Take(queryModel.ProjectsPerPage)
                .Select(b => new ProjectAllViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    TicketCount = b.Tickets.Count
                })
                .ToArrayAsync();

            int totalProjectsCount = projectQuery.Count();

            return new AllProjectsFilteredAndOrdered()
            {
                TotalProjectsCount = totalProjectsCount,
                Projects = projects
            };
        }

        public async Task<ProjectDetailsViewModel> FillModel(ProjectDetailsViewModel model, int id)
        {
            Project project = await dbContext.Projects.Include(x => x.Tickets).FirstOrDefaultAsync(x => x.Id == id);

            model.Id = project.Id;
            model.Description = project.Description;
            model.IsDeleted = project.IsDeleted;
            model.Tickets = project.Tickets.Select(x => new TicketDetailsViewModel
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Creator = x.Creator,
                Type = x.Type,
                State = x.State,
                Heading = x.Heading,
                Description = x.Description,
                Messages = x.Messages.Select(x => new MessageDetailsViewModelMessage
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Creator = x.Creator,
                    State = x.State,
                    Content = x.Content,
                    TicketId = x.TicketId,
                    IsDeleted = x.IsDeleted
                }).ToList(),
                IsDeleted = x.IsDeleted
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

            project.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }
    }
}
