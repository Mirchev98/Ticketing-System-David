using Microsoft.AspNetCore.Http;

namespace TicketingSystem.Services.Models.Ticket
{
    public class DownloadFilesTicketServices
    {
        public int Id { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }

        public string? ContentType { get; set; }
    }
}
