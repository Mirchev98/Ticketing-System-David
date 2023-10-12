using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Web.ViewModels.Project
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
