using TicketingSystem.Data.Common;

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

        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalProjectsCount / DataConstants.ProjectsPerPage);
        public string SearchTerm { get; set; }
        public string SortOrder { get; set; }
    }
}
