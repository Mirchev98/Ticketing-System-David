using System.ComponentModel.DataAnnotations;
using TicketingSystem.Services.ViewModels.Project.Enums;

namespace TicketingSystem.Services.Models.Project
{
    public class ProjectAllQueryModelServices
    {
        public ProjectAllQueryModelServices()
        {
            CurrentPage = 1;
            ProjectsPerPage = 6;

            Projects = new List<ProjectAllViewModelServices>();
        }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Projects By")]
        public ProjectSortEnumServices ProjectSorting { get; set; }

        public int CurrentPage { get; set; }

        public int ProjectsPerPage { get; set; }

        public int TotalProjects { get; set; }

        public IEnumerable<ProjectAllViewModelServices> Projects { get; set; }
    }
}
