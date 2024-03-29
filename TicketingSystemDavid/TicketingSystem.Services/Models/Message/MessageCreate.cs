﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TicketingSystem.Data.Common;

namespace TicketingSystem.Services.Models.Message
{
    public class MessageCreate
    {
        public int Id { get; set; }

        [Required]
        public MessageState State { get; set; }

        public string CreatorName { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        [Required]
        [StringLength(DataConstants.MessageContentMaxLen, MinimumLength = DataConstants.MessageContentMinLen)]
        public string Content { get; set; } = null!;

        public int TicketId { get; set; }

        [AllowNull]
        public byte[]? File { get; set; }
    }
}
