using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Common;

namespace TicketingSystem.Web.ViewModels.Project
{
    public class CreateProjectViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.ProjectNameMaxLen, MinimumLength = DataConstants.ProjectNameMinLen)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ProjectNameMaxLen, MinimumLength = DataConstants.ProjectDescriptionMinLen)]
        public string Description { get; set; } = null!;
    }
}
