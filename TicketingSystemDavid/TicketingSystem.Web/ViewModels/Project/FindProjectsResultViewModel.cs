namespace TicketingSystemDavid.ViewModels.Project
{
    public class FindProjectsResultViewModel
    {
        public FindProjectsResultViewModel()
        {
            Projects = new List<ProjectAllViewModel>();
        }

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectAllViewModel> Projects { get; set; }
    }
}
