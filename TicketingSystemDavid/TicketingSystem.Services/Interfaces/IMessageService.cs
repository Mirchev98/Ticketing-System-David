using TicketingSystem.Services.Models.File;
using TicketingSystem.Services.Models.Message;

namespace TicketingSystem.Services.Interfaces
{
    public interface IMessageService
    {
        Task Create(CreateMessageModelService model, string creator);

        Task<CreateMessageModelService> FillModel(CreateMessageModelService model, int id);

        Task Edit(CreateMessageModelService model, int id, string creator);

        Task Delete(int id);

        Task<DownloadFileModel> Download(int id);

        Task<int> FindTicket(int id);
    }
}
