using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Common;

namespace TicketingSystem.Data.Models
{
    public class Project
    {
        public Project()
        {
            Tickets = new List<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.ProjectNameMaxLen)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength (DataConstants.ProjectNameMaxLen)]
        public string Description { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; }
    }
}
