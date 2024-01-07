using Microsoft.AspNetCore.Http;

namespace TicketingSystem.Services.Models.Message
{
    public class MessageDetailsViewModelService
    {
        public int Id { get; set; }

        public string Creator { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public MessageStateService State { get; set; } 

        public string Content { get; set; } = null!;

        public int TicketId { get; set; }

        public bool IsDeleted { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }
    }
}
