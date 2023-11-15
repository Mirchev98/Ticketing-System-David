using TicketingSystemDavid.ViewModels.Ticket;

namespace TicketingSystemDavid.ViewModels.Project
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel()
        {
            Tickets = new List<TicketDetailsViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<TicketDetailsViewModel> Tickets { get; set; }

        public bool IsDeleted { get; set; }
    }
}
