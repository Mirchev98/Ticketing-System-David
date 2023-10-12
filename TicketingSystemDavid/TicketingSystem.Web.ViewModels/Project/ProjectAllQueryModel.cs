using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Web.ViewModels.Project.Enums;

namespace TicketingSystem.Web.ViewModels.Project
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
