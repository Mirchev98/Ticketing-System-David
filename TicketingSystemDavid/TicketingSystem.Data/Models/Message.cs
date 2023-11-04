using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using TicketingSystem.Common;

namespace TicketingSystem.Data.Models
{
    public class Message
    {
        public Message()
        {
            CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        public string Creator { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [Required]
        public string State { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.MessageContentMaxLen)]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(Ticket))]
        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        public bool IsDeleted { get; set; }

        [AllowNull]
        public string? FileName { get; set; }

        [AllowNull]
        public byte[]? FileContent { get; set; }

        [AllowNull]
        public string? ContentType { get; set; }
    }
}
