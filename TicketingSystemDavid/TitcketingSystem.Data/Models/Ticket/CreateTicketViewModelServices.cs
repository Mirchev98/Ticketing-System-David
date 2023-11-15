using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Common;
using TicketingSystem.Services.Models.Ticket.Enums;

namespace TicketingSystem.Services.Models.Ticket
{
    public class CreateTicketViewModelServices
    {
        public int Id { get; set; }

        public string Creator { get; set; } = null!;

        public int ProjectId { get; set; }
        
        public string Heading { get; set; }

        public string Description { get; set; }

        public TicketCategory Type { get; set; }

        public TicketState State { get; set; }

        public IFormFile File { get; set; }

        public string? FileName { get; set; }

        public byte[]? FileContent { get; set; }

        public string? ContentType { get; set; }
    }
}
