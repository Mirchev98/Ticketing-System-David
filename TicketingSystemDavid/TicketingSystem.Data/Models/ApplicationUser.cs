﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TicketingSystem.Common;

namespace TicketingSystem.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            IsAuthorized = false;
            IsAdmin = false;
            IsSupport = false;
        }

        public bool IsAdmin { get; set; }

        public bool IsSupport { get; set; }

        public bool IsAuthorized { get; set; }

        public string? AppliedRole { get; set; }

        [Required]
        [MaxLength(DataConstants.UserFirstNameMaxLen)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.UserLastNameMaxLen)]
        public string LastName { get; set; } = null!;
    }
}