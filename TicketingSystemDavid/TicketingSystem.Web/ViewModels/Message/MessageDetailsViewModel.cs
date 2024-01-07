using TicketingSystem.Web.ViewModels.Message;

namespace TicketingSystemDavid.ViewModels.Message
{
    public class MessageDetailsViewModel
    {
        public int Id { get; set; }

        public string Creator { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public MessageState State { get; set; } 

        public string Content { get; set; } = null!;

        public int TicketId { get; set; }

        public bool IsDeleted { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }
    }
}
