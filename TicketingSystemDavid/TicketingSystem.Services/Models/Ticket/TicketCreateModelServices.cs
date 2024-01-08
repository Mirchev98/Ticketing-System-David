namespace TicketingSystem.Services.Models.Ticket
{
    public class TicketCreateModelServices
    {
        public int Id { get; set; }

        public string Creator { get; set; } = null!;

        public int ProjectId { get; set; }
        
        public string Heading { get; set; }

        public string Description { get; set; }

        public TicketCategoryServices Type { get; set; }

        public TicketStateServices State { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }

        public string? ContentType { get; set; }
    }
}
