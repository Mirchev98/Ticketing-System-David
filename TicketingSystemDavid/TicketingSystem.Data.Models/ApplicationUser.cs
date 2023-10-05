﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Common;

namespace TicketingSystem.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public bool IsAdmin { get; set; }

        public bool IsAuthorized { get; set; }

        [Required]
        public string AppliedRole { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.UserFirstNameMinLen)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.UserLastNameMaxLen)]
        public string LastName { get; set; } = null!;
    }
}
