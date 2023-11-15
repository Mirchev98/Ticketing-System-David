using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Services.Models.Ticket;

namespace TicketingSystem.Services.Models.Project
{
    public class ProjectDetailsViewModelServices
    {
        public ProjectDetailsViewModelServices()
        {
            Tickets = new List<TicketDetailsViewModelServices>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<TicketDetailsViewModelServices> Tickets { get; set; }

        public bool IsDeleted { get; set; }
    }
}
