using TicketingSystem.Services.Models.Message;

namespace TicketingSystem.Services.Interfaces
{
    public interface IMessageService
    {
        Task Create(CreateMessageModelService model);

        Task<CreateMessageModelService> FillModel(CreateMessageModelService model, int id);

        Task Edit(CreateMessageModelService model, int id);

        Task Delete(int id);

        Task<DownloadFilesModelService> Download(int id);

        Task<int> FindTicket(int id);
    }
}
