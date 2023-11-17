using Microsoft.AspNetCore.Http;
using TicketingSystem.Services.Models.Message;

namespace TicketingSystem.Services.Models.Ticket
{
    public class TicketDetailsViewModelServices
    {
        public TicketDetailsViewModelServices()
        {
            Messages = new List<MessageDetailsViewModelServices>();
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Creator { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Heading { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<MessageDetailsViewModelServices> Messages { get; set; }

        public bool IsDeleted { get; set; }

        public IFormFile File { get; set; }
    }
}
