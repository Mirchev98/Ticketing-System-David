using TicketingSystemDavid.ViewModels.Message;

namespace TicketingSystemDavid.ViewModels.Ticket
{
    public class TicketDetailsView
    {
        public TicketDetailsView()
        {
            Messages = new List<MessageDetailsView>();
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

        public ICollection<MessageDetailsView> Messages { get; set; }

        public bool SoftDleted { get; set; }

        public byte[]? File { get; set; }
    }
}
