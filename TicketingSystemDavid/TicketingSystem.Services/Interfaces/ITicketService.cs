using TicketingSystem.Services.Models.File;
using TicketingSystem.Services.Models.Ticket;

namespace TicketingSystem.Services.Interfaces
{
    public interface ITicketService
    {
        Task Create(TicketCreate model);

        Task<TicketDetails> Details(TicketDetails model, int id);

        Task<TicketCreate> FillModel(TicketCreate model, int id);

        Task Edit(TicketCreate model, int id);

        Task Delete(int id);

        Task<DownloadFileModel> Download(int id);

        Task<int> FindProjectId(int id);
    }
}
