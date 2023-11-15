using System.ComponentModel.DataAnnotations;
using TicketingSystem.Common;

namespace TicketingSystemDavid.ViewModels.Project
{
    public class CreateProjectViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.ProjectNameMaxLen, MinimumLength = DataConstants.ProjectNameMinLen)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ProjectDescriptionMaxLen, MinimumLength = DataConstants.ProjectDescriptionMinLen)]
        public string Description { get; set; } = null!;
    }
}
