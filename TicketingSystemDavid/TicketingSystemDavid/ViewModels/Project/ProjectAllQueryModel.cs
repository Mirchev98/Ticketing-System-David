using System.ComponentModel.DataAnnotations;
using TicketingSystemDavid.ViewModels.Project.Enums;

namespace TicketingSystemDavid.ViewModels.Project
{
    public class ProjectAllQueryModel
    {
        public ProjectAllQueryModel()
        {
            CurrentPage = 1;
            ProjectsPerPage = 6;

            Projects = new List<ProjectAllViewModel>();
        }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Projects By")]
        public ProjectSortEnum ProjectSorting { get; set; }

        public int CurrentPage { get; set; }

        public int ProjectsPerPage { get; set; }

        public int TotalProjects { get; set; }

        public IEnumerable<ProjectAllViewModel> Projects { get; set; }
    }
}
