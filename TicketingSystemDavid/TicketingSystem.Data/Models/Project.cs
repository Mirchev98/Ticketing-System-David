using System.ComponentModel.DataAnnotations;
using TicketingSystem.Data.Common;

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
        [MaxLength (DataConstants.ProjectDescriptionMaxLen)]
        public string Description { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; }

        public bool IsDeleted { get; set; }
    }
}
