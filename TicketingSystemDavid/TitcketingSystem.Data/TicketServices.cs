using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.ViewModels.Message;
using TicketingSystem.Web.ViewModels.Ticket;
using TitcketingSystem.Data.Interfaces;

namespace TitcketingSystem.Data
{
    public class TicketServices : ITicketServices
    {
        private readonly TicketingSystemDbContext dbContext;

        public TicketServices(TicketingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(CreateTicketViewModel model)
        {
            Ticket ticket = new Ticket();

            ticket.ProjectId = model.ProjectId;
            ticket.Creator = model.Creator;
            ticket.State = model.State.ToString();
            ticket.Heading = model.Heading;
            ticket.Description = model.Description;
            ticket.Type = model.Type.ToString();
            ticket.FileContent = model.FileContent;
            ticket.ContentType = model.ContentType;
            ticket.FileName = model.FileName;

            await dbContext.Tickets.AddAsync(ticket);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);
            
            ticket.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task<TicketDetailsViewModel> Details(TicketDetailsViewModel model, int id)
        {
            Ticket ticket = await dbContext.Tickets.Include(x => x.Messages).FirstOrDefaultAsync(t => t.Id == id);

            model.Id = ticket.Id;
            model.ProjectId = ticket.ProjectId;
            model.Creator = ticket.Creator;
            model.State = ticket.State;
            model.Heading = ticket.Heading;
            model.Description = ticket.Description;
            model.Type = ticket.Type;
            model.IsDeleted = ticket.IsDeleted;
            model.Messages = ticket.Messages.Select(x => new MessageDetailsViewModel
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Creator = x.Creator,
                State = x.State,
                Content = x.Content,
                TicketId = x.TicketId,
                IsDeleted = x.IsDeleted
            }).ToList();

            return model;
        }

        public async Task Edit(CreateTicketViewModel model, int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            //ticket.ProjectId = model.ProjectId;
            ticket.Creator = model.Creator;
            ticket.Heading = model.Heading;
            ticket.Description = model.Description;
            ticket.Type = model.Type.ToString();
            ticket.State = model.State.ToString();

            await dbContext.SaveChangesAsync();
        }

        public async Task<CreateTicketViewModel> FillModel(CreateTicketViewModel model, int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            model.Id = ticket.Id;
            model.ProjectId = ticket.ProjectId;
            model.Creator = ticket.Creator;
            model.Heading = ticket.Heading;
            model.Description = ticket.Description;

            return model;
        }

        public async Task<Ticket> Find(int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            return ticket;
        }
    }
}
