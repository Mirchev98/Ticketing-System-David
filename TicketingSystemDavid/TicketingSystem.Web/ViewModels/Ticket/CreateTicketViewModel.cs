using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TicketingSystem.Data.Common;
using TicketingSystem.Web.ViewModels.Ticket;

namespace TicketingSystemDavid.ViewModels.Ticket
{
    public class CreateTicketViewModel
    {
        public int Id { get; set; }

        [AllowNull]
        public string? Creator { get; set; }

        public int ProjectId { get; set; }

        [Required]
        [StringLength(DataConstants.TicketHeadingMaxLen, MinimumLength = DataConstants.TicketHeadingMinLen)]
        public string Heading { get; set; }

        [Required]
        [StringLength(DataConstants.TicketDescriptionMaxLen, MinimumLength = DataConstants.TicketDescriptionMinLen)]
        public string Description { get; set; }

        public TicketCategory Type { get; set; }

        public TicketState State { get; set; }

        [AllowNull]
        public byte[]? File { get; set; }

        [AllowNull]
        public string? FileName { get; set; }

        [AllowNull]
        public byte[]? FileContent { get; set; }

        [AllowNull]
        public string? ContentType { get; set; }
    }
}
