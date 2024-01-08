using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Project;

namespace TicketingSystem.Services.Interfaces
{
    public interface IProjectService
    {
        Task Create(CreateProjectViewModelServices model);

        //Task<FindProjectsResultViewModelServices> AllAsync(FindProjectsRequestViewModelServices queryModel);

        Task<ProjectDetailsViewModelServices> FillModel(ProjectDetailsViewModelServices model, int id);

        Task<Project> FindProject(int id);

        Task Delete(int id);

        Task<FindProjectsResultViewModelServices> GetProjectsAsync(string searchTerm, string sortOrder, int page, int pageSize);
    }
}
