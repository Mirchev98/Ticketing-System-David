using TicketingSystem.Services.Models.Ticket;

namespace TicketingSystem.Services.Models.Project
{
    public class ProjectDetailsModelServices
    {
        public ProjectDetailsModelServices()
        {
            Tickets = new List<TicketDetailsModelServices>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<TicketDetailsModelServices> Tickets { get; set; }

        public bool IsDeleted { get; set; }
    }
}
