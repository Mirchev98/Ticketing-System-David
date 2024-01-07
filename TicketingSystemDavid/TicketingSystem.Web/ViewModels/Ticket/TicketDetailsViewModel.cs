using TicketingSystemDavid.ViewModels.Message;

namespace TicketingSystemDavid.ViewModels.Ticket
{
    public class TicketDetailsViewModel
    {
        public TicketDetailsViewModel()
        {
            Messages = new List<MessageDetailsViewModel>();
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Creator { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Heading { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<MessageDetailsViewModel> Messages { get; set; }

        public bool IsDeleted { get; set; }

        public IFormFile File { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }
    }
}
