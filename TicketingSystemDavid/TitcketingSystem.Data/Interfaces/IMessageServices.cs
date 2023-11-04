using TicketingSystem.Data.Models;
using TicketingSystem.Services.ViewModels.Message;
using TicketingSystem.Services.ViewModels.Ticket;

namespace TicketingSystem.Data.Interfaces
{
    public interface IMessageServices
    {
        Task Create(CreateMessageViewModel model);

        Task<CreateMessageViewModel> FillModel(CreateMessageViewModel model, int id);

        Task Edit(CreateMessageViewModel model, int id);

        Task Delete(int id);

        Task<DownloadFilesViewModelMessage> Download(int id);
    }
}
