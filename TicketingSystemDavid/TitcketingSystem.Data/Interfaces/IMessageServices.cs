using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Message;

namespace TicketingSystem.Data.Interfaces
{
    public interface IMessageServices
    {
        Task Create(CreateMessageModelServices model);

        Task<CreateMessageModelServices> FillModel(CreateMessageModelServices model, int id);

        Task Edit(CreateMessageModelServices model, int id);

        Task Delete(int id);

        Task<DownloadFilesModelServices> Download(int id);
    }
}
