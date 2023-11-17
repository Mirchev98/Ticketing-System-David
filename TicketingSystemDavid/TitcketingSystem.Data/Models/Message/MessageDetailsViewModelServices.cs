using Microsoft.AspNetCore.Http;

namespace TicketingSystem.Services.Models.Message
{
    public class MessageDetailsViewModelServices
    {
        public int Id { get; set; }

        public string Creator { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string State { get; set; } = null!;

        public string Content { get; set; } = null!;

        public int TicketId { get; set; }

        public bool IsDeleted { get; set; }

        public IFormFile File { get; set; }
    }
}
