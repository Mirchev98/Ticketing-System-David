namespace TicketingSystem.Services.Models.Project
{
    public class ProjectAllViewModelServices
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public int TicketCount { get; set; }
    }
}
