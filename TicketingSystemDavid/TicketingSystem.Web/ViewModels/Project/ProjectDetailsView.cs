using TicketingSystemDavid.ViewModels.Ticket;

namespace TicketingSystemDavid.ViewModels.Project
{
    public class ProjectDetailsView
    {
        public ProjectDetailsView()
        {
            Tickets = new List<TicketDetailsView>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<TicketDetailsView> Tickets { get; set; }

        public bool SoftDleted { get; set; }
    }
}
