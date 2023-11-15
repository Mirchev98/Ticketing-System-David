namespace TicketingSystemDavid.ViewModels.Project
{
    public class AllProjectsFilteredAndOrdered
    {
        public AllProjectsFilteredAndOrdered()
        {
            Projects = new List<ProjectAllViewModel>();
        }

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectAllViewModel> Projects { get; set; }
    }
}
