namespace TicketingSystem.Services.Models.Project
{
    public class FindProjectsResultModelServices
    {
        public FindProjectsResultModelServices()
        {
            Projects = new List<ProjectViewModelServices>();
        }

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectViewModelServices> Projects { get; set; }
    }
}
