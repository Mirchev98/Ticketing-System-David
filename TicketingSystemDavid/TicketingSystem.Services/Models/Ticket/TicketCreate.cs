namespace TicketingSystem.Services.Models.Ticket
{
    public class TicketCreate
    {
        public int Id { get; set; }

        public string CreatorName { get; set; } = null!;

        public string CreatorId { get; set; }

        public int ProjectId { get; set; }
        
        public string Heading { get; set; }

        public string Description { get; set; }

        public TicketCategory Type { get; set; }

        public TicketState State { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }

        public string? ContentType { get; set; }
    }
}
