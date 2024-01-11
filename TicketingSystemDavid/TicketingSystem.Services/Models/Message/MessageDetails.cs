namespace TicketingSystem.Services.Models.Message
{
    public class MessageDetails
    {
        public int Id { get; set; }

        public string CreatorName { get; set; } = null!;

        public string CreatorId { get; set; }

        public DateTime CreatedOn { get; set; }

        public MessageState State { get; set; } 

        public string Content { get; set; } = null!;

        public int TicketId { get; set; }

        public bool SoftDeleted { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }
    }
}
