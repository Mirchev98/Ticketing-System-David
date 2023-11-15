using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Ticket;

namespace TicketingSystem.Data.Interfaces
{
    public interface ITicketServices
    {
        Task Create(CreateTicketViewModelServices model); 

        Task<TicketDetailsViewModelServices> Details(TicketDetailsViewModelServices model, int id);

        Task<CreateTicketViewModelServices> FillModel(CreateTicketViewModelServices model, int id);

        Task Edit(CreateTicketViewModelServices model, int id);

        Task Delete(int id);

        Task<DownloadFilesTicketServices> Download(int id);
    }
}
