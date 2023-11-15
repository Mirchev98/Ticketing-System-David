using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
