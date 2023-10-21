using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Common;
using TicketingSystem.Web.ViewModels.Ticket;

namespace TicketingSystem.Web.ViewModels.Project
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel()
        {
            Tickets = new List<TicketDetailsViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<TicketDetailsViewModel> Tickets { get; set; }

        public bool IsDeleted { get; set; }
    }
}
