using System.Diagnostics.CodeAnalysis;
using TicketingSystem.Services.Models.Message;

namespace TicketingSystem.Services.Models.Ticket
{
    public class TicketDetails
    {
        public TicketDetails()
        {
            Messages = new List<MessageDetails>();
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorName { get; set; } = null!;

        public string CreatorId { get; set; }

        public string Type { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Heading { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<MessageDetails> Messages { get; set; }

        public bool SoftDeleted { get; set; }

        public byte[]? File { get; set; }
    }
}
