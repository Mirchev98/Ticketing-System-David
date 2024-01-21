namespace TicketingSystemDavid.ViewModels.Project
{
    public class ProjectInformationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool SoftDleted { get; set; }

        public int TicketCount { get; set; }
    }
}
