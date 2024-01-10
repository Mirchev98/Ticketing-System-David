using TicketingSystem.Services.Models.File;
using TicketingSystem.Services.Models.Message;

namespace TicketingSystem.Services.Interfaces
{
    public interface IMessageService
    {
        Task Create(CreateMessage model, string creator);

        Task<CreateMessage> FillModel(CreateMessage model, int id);

        Task Edit(CreateMessage model, int id, string creator);

        Task Delete(int id);

        Task<DownloadFileModel> Download(int id);

        Task<int> FindTicket(int id);
    }
}
