using TicketingSystem.Data.Models;
using TicketingSystem.Services.ViewModels.Ticket;

namespace TicketingSystem.Data.Interfaces
{
    public interface ITicketServices
    {
        Task Create(CreateTicketViewModel model); 

        Task<TicketDetailsViewModel> Details(TicketDetailsViewModel model, int id);

        Task<CreateTicketViewModel> FillModel(CreateTicketViewModel model, int id);

        Task Edit(CreateTicketViewModel model, int id);

        Task Delete(int id);

        Task<DownloadFilesViewModelTicket> Download(int id);
    }
}
