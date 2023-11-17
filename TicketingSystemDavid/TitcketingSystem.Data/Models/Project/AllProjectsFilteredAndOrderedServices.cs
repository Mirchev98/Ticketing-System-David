namespace TicketingSystem.Services.Models.Project
{
    public class AllProjectsFilteredAndOrderedServices
    {
        public AllProjectsFilteredAndOrderedServices()
        {
            Projects = new List<ProjectAllViewModelServices>();
        }

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectAllViewModelServices> Projects { get; set; }
    }
}
