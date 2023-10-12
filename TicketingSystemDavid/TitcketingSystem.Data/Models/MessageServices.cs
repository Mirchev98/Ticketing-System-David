using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.ViewModels.Message;
using TitcketingSystem.Data.Interfaces;

namespace TitcketingSystem.Data.Models
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

            await dbContext.Messages.AddAsync(message);
            await dbContext.SaveChangesAsync();
        }
    }
}
