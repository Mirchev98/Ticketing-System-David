using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Project;

namespace TicketingSystem.Services.Interfaces
{
    public interface IProjectService
    {
        Task Create(ProjectCreate model);

        //Task<FindProjectsResultViewModelServices> AllAsync(FindProjectsRequestViewModelServices queryModel);

        Task<ProjectDetails> FillModel(ProjectDetails model, int id);

        Task<Project> FindProject(int id);

        Task Delete(int id);

        Task<FindProjectsResult> GetProjectsAsync(string searchTerm, string sortOrder, int page, int pageSize);
    }
}
