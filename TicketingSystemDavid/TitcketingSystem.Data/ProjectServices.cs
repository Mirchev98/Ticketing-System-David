using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.ViewModels.Project;
using TicketingSystem.Web.ViewModels.Project.Enums;
using TitcketingSystem.Data.Interfaces;

namespace TitcketingSystem.Data
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
    }
}
