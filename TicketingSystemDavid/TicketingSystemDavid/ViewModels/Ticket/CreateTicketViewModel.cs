using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TicketingSystem.Common;
using TicketingSystemDavid.ViewModels.Ticket.Enums;

namespace TicketingSystemDavid.ViewModels.Ticket
{
    public class CreateTicketViewModel
    {
        public int Id { get; set; }

        public string Creator { get; set; } = null!;

        public int ProjectId { get; set; }

        [Required]
        [StringLength(DataConstants.TicketHeadingMaxLen, MinimumLength = DataConstants.TicketHeadingMinLen)]
        public string Heading { get; set; }

        [Required]
        [StringLength(DataConstants.TicketDescriptionMaxLen, MinimumLength = DataConstants.TicketDescriptionMinLen)]
        public string Description { get; set; }

        public TicketCategory Type { get; set; }

        public TicketState State { get; set; }

        public IFormFile File { get; set; }

        [AllowNull]
        public string? FileName { get; set; }

        [AllowNull]
        public byte[]? FileContent { get; set; }

        [AllowNull]
        public string? ContentType { get; set; }
    }
}
