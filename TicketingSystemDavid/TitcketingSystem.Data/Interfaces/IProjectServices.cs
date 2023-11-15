using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Project;

namespace TicketingSystem.Data.Interfaces
{
    public interface IProjectServices
    {
        Task Create(CreateProjectViewModelServices model);

        Task<AllProjectsFilteredAndOrderedServices> AllAsync(ProjectAllQueryModelServices queryModel);

        Task<ProjectDetailsViewModelServices> FillModel(ProjectDetailsViewModelServices model, int id);

        Task<Project> FindProject(int id);

        Task Delete(int id);
    }
}
