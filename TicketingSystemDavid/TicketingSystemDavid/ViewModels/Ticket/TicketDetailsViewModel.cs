using Microsoft.AspNetCore.Http;
using TicketingSystemDavid.ViewModels.Message;

namespace TicketingSystemDavid.ViewModels.Ticket
{
    public class TicketDetailsViewModel
    {
        public TicketDetailsViewModel()
        {
            Messages = new List<MessageDetailsViewModelMessage>();
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Creator { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Heading { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<MessageDetailsViewModelMessage> Messages { get; set; }

        public bool IsDeleted { get; set; }

        public IFormFile File { get; set; }
    }
}
