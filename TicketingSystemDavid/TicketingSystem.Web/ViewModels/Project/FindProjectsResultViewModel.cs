using TicketingSystem.Data.Common;

namespace TicketingSystemDavid.ViewModels.Project
{
    public class FindProjectsResultViewModel
    {
        public FindProjectsResultViewModel()
        {
            Projects = new List<ProjectInformationViewModel>();
        }

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectInformationViewModel> Projects { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalProjectsCount / DataConstants.ProjectsPerPage);
        public string SearchTerm { get; set; }
        public string SortOrder { get; set; }
    }
}
