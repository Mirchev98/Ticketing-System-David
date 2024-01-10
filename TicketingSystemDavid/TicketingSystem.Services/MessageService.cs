using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Message;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Data;
using TicketingSystem.Services.Models.File;

namespace TicketingSystem.Services
{
    public class MessageService : IMessageService
    {
        private readonly TicketingSystemDbContext dbContext;

        public MessageService(TicketingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(CreateMessage model, string creator)
        {
            Message message = new Message();

            message.State = model.State.ToString();
            message.Content = model.Content;
            message.CreatorEmail = creator;
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

            message.SoftDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task<DownloadFileModel> Download(int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            DownloadFileModel model = new DownloadFileModel();

            model.FileContent = message.FileContent;
            model.ContentType = message.ContentType;
            model.FileName = message.FileName;

            return model;
        }

        public async Task Edit(CreateMessage model, int id, string creator)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            message.State = model.State.ToString();
            message.Content = model.Content;
            message.CreatorEmail = creator;
            message.CreatedOn = DateTime.Now;

            await dbContext.SaveChangesAsync();
        }

        public async Task<CreateMessage> FillModel(CreateMessage model, int id)
        {
            Message message = await dbContext.Messages.Include(x => x.Ticket).FirstOrDefaultAsync(x => x.Id == id);

            model.Content = message.Content;
            model.Creator = message.CreatorEmail;
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
