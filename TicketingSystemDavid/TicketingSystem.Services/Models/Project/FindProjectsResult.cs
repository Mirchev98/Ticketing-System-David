namespace TicketingSystem.Services.Models.Project
{
    public class FindProjectsResult
    {
        public FindProjectsResult()
        {
            Projects = new List<ProjectViewModelServices>();
        }

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectViewModelServices> Projects { get; set; }
    }
}
