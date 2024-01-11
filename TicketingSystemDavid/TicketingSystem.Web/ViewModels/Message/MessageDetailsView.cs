using TicketingSystem.Web.ViewModels.Message;

namespace TicketingSystemDavid.ViewModels.Message
{
    public class MessageDetailsView
    {
        public int Id { get; set; }

        public string CreatorName { get; set; } = null!;

        public string CreatorId { get; set; }

        public DateTime CreatedOn { get; set; }

        public MessageState State { get; set; } 

        public string Content { get; set; } = null!;

        public int TicketId { get; set; }

        public bool IsDeleted { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }
    }
}
