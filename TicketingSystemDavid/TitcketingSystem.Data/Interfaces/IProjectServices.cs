using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.ViewModels.Project;

namespace TitcketingSystem.Data.Interfaces
{
    public interface IProjectServices
    {
        Task Create(CreateProjectViewModel model);

        Task<AllProjectsFilteredAndOrdered> AllAsync(ProjectAllQueryModel queryModel);

        Task<ProjectDetailsViewModel> FillModel(ProjectDetailsViewModel model, int id);

        Task<Project> FindProject(int id);

        Task Delete(int id);
    }
}
