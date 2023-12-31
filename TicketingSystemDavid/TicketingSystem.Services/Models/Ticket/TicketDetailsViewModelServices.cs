﻿using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;
using TicketingSystem.Services.Models.Message;

namespace TicketingSystem.Services.Models.Ticket
{
    public class TicketDetailsViewModelServices
    {
        public TicketDetailsViewModelServices()
        {
            Messages = new List<MessageDetailsViewModelService>();
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Creator { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Heading { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<MessageDetailsViewModelService> Messages { get; set; }

        public bool IsDeleted { get; set; }

        [AllowNull]
        public FileStream File { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }
    }
}
