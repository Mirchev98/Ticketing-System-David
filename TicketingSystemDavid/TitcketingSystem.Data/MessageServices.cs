using TicketingSystem.Data.Models;
using TicketingSystem.Data.Interfaces;
using TicketingSystem.Services.ViewModels.Message;
using TicketingSystem.Services.ViewModels.Ticket;

namespace TicketingSystem.Data
{
    public class MessageServices : IMessageServices
    {
        private readonly TicketingSystemDbContext dbContext;

        public MessageServices(TicketingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(CreateMessageViewModel model)
        {
            Message message = new Message();

            message.State = model.State.ToString();
            message.Content = model.Content;
            message.Creator = model.Creator;
            message.TicketId = model.TicketId;
            message.FileContent = model.FileContent;
            message.ContentType = model.ContentType;
            message.FileName = model.FileName;

            await dbContext.Messages.AddAsync(message);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            message.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task<DownloadFilesViewModelMessage> Download(int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            DownloadFilesViewModelMessage model = new DownloadFilesViewModelMessage();

            model.FileContent = message.FileContent;
            model.ContentType = message.ContentType;
            model.FileName = message.FileName;

            return model;
        }

        public async Task Edit(CreateMessageViewModel model, int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            message.State = model.State.ToString();
            message.Content = model.Content;
            message.Creator = model.Creator;

            await dbContext.SaveChangesAsync();
        }

        public async Task<CreateMessageViewModel> FillModel(CreateMessageViewModel model, int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            model.Content = message.Content;
            model.Creator = message.Creator;

            return model;
        }
    }
}
