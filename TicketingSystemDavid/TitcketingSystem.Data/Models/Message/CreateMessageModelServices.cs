using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TicketingSystem.Common;
using TicketingSystem.Services.Models.Message.Enums;

namespace TicketingSystem.Services.Models.Message
{
    public class CreateMessageModelServices
    {
        public int Id { get; set; }

        [Required]
        public MessageStateServices State { get; set; }

        public string Creator { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(DataConstants.MessageContentMaxLen, MinimumLength = DataConstants.MessageContentMinLen)]
        public string Content { get; set; } = null!;

        public int TicketId { get; set; }

        public IFormFile File { get; set; }

        [AllowNull]
        public string? FileName { get; set; }

        [AllowNull]
        public byte[]? FileContent { get; set; }

        [AllowNull]
        public string? ContentType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
