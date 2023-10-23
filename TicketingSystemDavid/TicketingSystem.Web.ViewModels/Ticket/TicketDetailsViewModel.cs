using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Common;
using TicketingSystem.Web.ViewModels.Message;

namespace TicketingSystem.Web.ViewModels.Ticket
{
    public class TicketDetailsViewModel
    {
        public TicketDetailsViewModel()
        {
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Creator { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Heading { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int MessagesCount { get; set; }

        public bool IsDeleted { get; set; }
    }
}
