namespace TicketingSystem.Services.Models.Project
{
    public class ProjectViewModelServices
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool SoftDeleted { get; set; }

        public int TicketCount { get; set; }
    }
}
