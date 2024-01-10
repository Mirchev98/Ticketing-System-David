namespace TicketingSystem.Services.Models.Project
{
    public class ProjectCreate
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
