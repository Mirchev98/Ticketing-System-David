using System.ComponentModel.DataAnnotations;
using TicketingSystem.Web.ViewModels.Project;

namespace TicketingSystemDavid.ViewModels.Project
{
    public class FindProjectsRequestViewModel
    {
        public FindProjectsRequestViewModel()
        {
            CurrentPage = 1;
            ProjectsPerPage = 6;

            Projects = new List<ProjectAllViewModel>();
        }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Projects By")]
        public ProjectSort ProjectSorting { get; set; }

        public int CurrentPage { get; set; }

        public int ProjectsPerPage { get; set; }

        public int TotalProjects { get; set; }

        public IEnumerable<ProjectAllViewModel> Projects { get; set; }
    }
}
