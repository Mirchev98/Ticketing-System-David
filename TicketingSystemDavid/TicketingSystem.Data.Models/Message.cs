using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //public ApplicationUser Creator { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [Required]
        public string State { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.MessageContentMaxLen)]
        public string Content { get; set; } = null!;
    }
}
