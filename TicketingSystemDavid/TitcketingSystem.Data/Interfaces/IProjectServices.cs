using TicketingSystem.Data.Models;
using TicketingSystem.Services.ViewModels.Project;

namespace TicketingSystem.Data.Interfaces
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
