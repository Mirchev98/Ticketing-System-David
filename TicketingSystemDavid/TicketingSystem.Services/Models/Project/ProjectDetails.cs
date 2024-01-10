using TicketingSystem.Services.Models.Ticket;

namespace TicketingSystem.Services.Models.Project
{
    public class ProjectDetails
    {
        public ProjectDetails()
        {
            Tickets = new List<TicketDetails>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<TicketDetails> Tickets { get; set; }

        public bool IsDeleted { get; set; }
    }
}
