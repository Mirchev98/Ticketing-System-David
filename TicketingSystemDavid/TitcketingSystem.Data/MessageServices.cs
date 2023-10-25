using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.ViewModels.Message;
using TicketingSystem.Web.ViewModels.Message.Enums;
using TitcketingSystem.Data.Interfaces;

namespace TitcketingSystem.Data
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

        public async Task<Message> Find(int id)
        {
            Message message = await dbContext.Messages.FindAsync(id);

            return message;
        }
    }
}
