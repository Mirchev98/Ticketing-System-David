using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Project;

namespace TicketingSystem.Services.Interfaces
{
    public interface IProjectService
    {
        Task Create(ProjectCreateModelServices model);

        //Task<FindProjectsResultViewModelServices> AllAsync(FindProjectsRequestViewModelServices queryModel);

        Task<ProjectDetailsModelServices> FillModel(ProjectDetailsModelServices model, int id);

        Task<Project> FindProject(int id);

        Task Delete(int id);

        Task<FindProjectsResultModelServices> GetProjectsAsync(string searchTerm, string sortOrder, int page, int pageSize);
    }
}
