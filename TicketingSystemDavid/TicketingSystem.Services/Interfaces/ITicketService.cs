using TicketingSystem.Services.Models.File;
using TicketingSystem.Services.Models.Ticket;

namespace TicketingSystem.Services.Interfaces
{
    public interface ITicketService
    {
        Task Create(TicketCreateModelServices model);

        Task<TicketDetailsModelServices> Details(TicketDetailsModelServices model, int id);

        Task<TicketCreateModelServices> FillModel(TicketCreateModelServices model, int id);

        Task Edit(TicketCreateModelServices model, int id);

        Task Delete(int id);

        Task<DownloadFileModel> Download(int id);

        Task<int> FindProjectId(int id);
    }
}
