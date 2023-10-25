﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Common;

namespace TicketingSystem.Data.Models
{
    public class Ticket
    {
        public Ticket()
        {
            CreatedOn = DateTime.UtcNow;
            Messages = new List<Message>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Creator { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string State { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.TicketHeadingMaxLen)]
        public string Heading { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.TicketDescriptionMaxLen)]
        public string Description { get; set; } = null!;

        public ICollection<Message> Messages { get; set; }

        public bool IsDeleted { get; set; }

        [AllowNull]
        public string? FileName { get; set; }

        [AllowNull]
        public byte[]? FileContent { get; set; }

        [AllowNull]
        public string? ContentType { get; set; }
    }
}
