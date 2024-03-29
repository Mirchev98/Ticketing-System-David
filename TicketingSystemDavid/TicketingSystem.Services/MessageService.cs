﻿using TicketingSystem.Data.Models;
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

        public async Task Create(MessageCreate model)
        {
            Message message = new Message();

            message.State = model.State.ToString();
            message.Content = model.Content;
            message.CreatorEmail = model.CreatorName;
            message.CreatorId = model.CreatorId;
            message.TicketId = model.TicketId;
            message.File = model.File;
            message.CreatedOn = DateTime.Now;
            message.CreatorId = model.CreatorId;

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

            model.FileContent = message.File;

            return model;
        }

        public async Task Edit(MessageCreate model, int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            message.State = model.State.ToString();
            message.Content = model.Content;

            await dbContext.SaveChangesAsync();
        }

        public async Task<MessageCreate> FillModel(MessageCreate model, int id)
        {
            Message message = await dbContext.Messages.Include(x => x.Ticket).FirstOrDefaultAsync(x => x.Id == id);

            model.Content = message.Content;
            model.CreatorName = message.CreatorEmail;
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
