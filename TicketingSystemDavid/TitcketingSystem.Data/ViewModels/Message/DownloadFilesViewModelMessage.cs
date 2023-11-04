using Microsoft.AspNetCore.Http;

namespace TicketingSystem.Services.ViewModels.Ticket
{
    public class DownloadFilesViewModelMessage
    {
        public int Id { get; set; }

        public IFormFile File { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }

        public string? ContentType { get; set; }
    }
}
