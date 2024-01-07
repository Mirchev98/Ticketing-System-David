using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Message;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Data;

namespace TicketingSystem.Services
{
    public class MessageService : IMessageService
    {
        private readonly TicketingSystemDbContext dbContext;

        public MessageService(TicketingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(CreateMessageModelServices model)
        {
            Message message = new Message();

            message.State = model.State.ToString();
            message.Content = model.Content;
            message.Creator = model.Creator;
            message.TicketId = model.TicketId;
            message.FileContent = model.FileContent;
            message.ContentType = model.ContentType;
            message.FileName = model.FileName;
            message.CreatedOn = DateTime.Now;

            await dbContext.Messages.AddAsync(message);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            message.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task<DownloadFilesModelServices> Download(int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            DownloadFilesModelServices model = new DownloadFilesModelServices();

            model.FileContent = message.FileContent;
            model.ContentType = message.ContentType;
            model.FileName = message.FileName;

            return model;
        }

        public async Task Edit(CreateMessageModelServices model, int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            message.State = model.State.ToString();
            message.Content = model.Content;
            message.Creator = model.Creator;
            message.CreatedOn = DateTime.Now;

            await dbContext.SaveChangesAsync();
        }

        public async Task<CreateMessageModelServices> FillModel(CreateMessageModelServices model, int id)
        {
            Message message = await dbContext.Messages.Include(x => x.Ticket).FirstOrDefaultAsync(x => x.Id == id);

            model.Content = message.Content;
            model.Creator = message.Creator;
            model.CreatedOn = message.CreatedOn;
            model.TicketId = message.TicketId;

            return model;
        }

        public async Task<int> FindTicket(int id)
        {
            Message message = await dbContext.Messages.Include(x => x.Ticket).FirstOrDefaultAsync(x => x.Id == id);

            return message.TicketId;
        }
    }
}
