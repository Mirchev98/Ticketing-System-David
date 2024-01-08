namespace TicketingSystem.Services.Models.File
{
    public class DownloadFileModel
    {
        public int Id { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }

        public string? ContentType { get; set; }
    }
}
