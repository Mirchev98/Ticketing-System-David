using Microsoft.AspNetCore.Http;
using TicketingSystem.Services.Models.Ticket.Enums;

namespace TicketingSystem.Services.Models.Ticket
{
    public class CreateTicketViewModelServices
    {
        public int Id { get; set; }

        public string Creator { get; set; } = null!;

        public int ProjectId { get; set; }
        
        public string Heading { get; set; }

        public string Description { get; set; }

        public TicketCategory Type { get; set; }

        public TicketState State { get; set; }

        public IFormFile File { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }

        public string? ContentType { get; set; }
    }
}
