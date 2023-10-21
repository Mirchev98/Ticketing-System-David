using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Common;

namespace TicketingSystem.Web.ViewModels.Message
{
    public class MessageDetailsViewModel
    {
        public int Id { get; set; }

        public string Creator { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string State { get; set; } = null!;

        public string Content { get; set; } = null!;

        public int TicketId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
