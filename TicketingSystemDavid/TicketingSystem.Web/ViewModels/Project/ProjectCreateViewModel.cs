using System.ComponentModel.DataAnnotations;
using TicketingSystem.Data.Common;

namespace TicketingSystemDavid.ViewModels.Project
{
    public class ProjectCreateViewModel
    {

        [Required]
        [StringLength(DataConstants.ProjectNameMaxLen, MinimumLength = DataConstants.ProjectNameMinLen)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ProjectDescriptionMaxLen, MinimumLength = DataConstants.ProjectDescriptionMinLen)]
        public string Description { get; set; } = null!;
    }
}
