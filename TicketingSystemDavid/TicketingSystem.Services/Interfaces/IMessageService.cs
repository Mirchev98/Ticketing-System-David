using TicketingSystem.Services.Models.File;
using TicketingSystem.Services.Models.Message;

namespace TicketingSystem.Services.Interfaces
{
    public interface IMessageService
    {
        Task Create(MessageCreate model, string creator);

        Task<MessageCreate> FillModel(MessageCreate model, int id);

        Task Edit(MessageCreate model, int id, string creator);

        Task Delete(int id);

        Task<DownloadFileModel> Download(int id);

        Task<int> FindTicket(int id);
    }
}
