using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TicketingSystem.Common;
using TicketingSystemDavid.ViewModels.Message.Enums;

namespace TicketingSystemDavid.ViewModels.Message
{
    public class CreateMessageViewModel
    {
        public int Id { get; set; }

        [Required]
        public MessageState State { get; set; }

        public string Creator { get; set; } = null!;

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
    }
}
