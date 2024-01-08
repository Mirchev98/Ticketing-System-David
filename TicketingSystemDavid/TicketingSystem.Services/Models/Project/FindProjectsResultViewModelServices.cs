namespace TicketingSystem.Services.Models.Project
{
    public class FindProjectsResultViewModelServices
    {
        public FindProjectsResultViewModelServices()
        {
            Projects = new List<ProjectAllViewModelServices>();
        }

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectAllViewModelServices> Projects { get; set; }
    }
}
