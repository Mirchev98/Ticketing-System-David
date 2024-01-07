using TicketingSystem.Services.Models.Ticket;

namespace TicketingSystem.Services.Interfaces
{
    public interface ITicketService
    {
        Task Create(CreateTicketViewModelServices model);

        Task<TicketDetailsViewModelServices> Details(TicketDetailsViewModelServices model, int id);

        Task<CreateTicketViewModelServices> FillModel(CreateTicketViewModelServices model, int id);

        Task Edit(CreateTicketViewModelServices model, int id);

        Task Delete(int id);

        Task<DownloadFilesTicketServices> Download(int id);

        Task<int> FindProjectId(int id);
    }
}
