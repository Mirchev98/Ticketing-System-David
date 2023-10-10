using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.ViewModels.Project;
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
    }
}
