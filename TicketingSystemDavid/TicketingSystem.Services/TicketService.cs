﻿using Microsoft.EntityFrameworkCore;
using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.Ticket;
using TicketingSystem.Services.Models.Message;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Data;
using TicketingSystem.Services.Models.File;

namespace TicketingSystem.Services
{
    public class TicketService : ITicketService
    {
        private readonly TicketingSystemDbContext dbContext;

        public TicketService(TicketingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(TicketCreate model)
        {
            Ticket ticket = new Ticket();

            ticket.ProjectId = model.ProjectId;
            ticket.CreatorEmail = model.CreatorName;
            ticket.CreatorId = model.CreatorId;
            ticket.State = model.State.ToString();
            ticket.Heading = model.Heading;
            ticket.Description = model.Description;
            ticket.Type = model.Type.ToString();
            ticket.File = model.File;
            ticket.CreatedOn = DateTime.Now;

            await dbContext.Tickets.AddAsync(ticket);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            ticket.SoftDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task<TicketDetails> Details(TicketDetails model, int id)
        {
            Ticket ticket = await dbContext.Tickets.Include(x => x.Messages).FirstOrDefaultAsync(t => t.Id == id);

            model.Id = ticket.Id;
            model.ProjectId = ticket.ProjectId;
            model.CreatorName = ticket.CreatorEmail;
            model.CreatorId = ticket.CreatorId;
            model.State = ticket.State;
            model.Heading = ticket.Heading;
            model.Description = ticket.Description;
            model.Type = ticket.Type;
            model.SoftDeleted = ticket.SoftDeleted;
            model.File = ticket.File;
            model.Messages = ticket.Messages.Select(x => new MessageDetails
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                CreatorName = x.CreatorEmail,
                State = (MessageState)Enum.Parse(typeof(MessageState), x.State.ToString()),
                Content = x.Content,
                TicketId = x.TicketId,
                SoftDeleted = x.SoftDeleted,
                File = x.File
            }).ToList();

            return model;
        }

        public async Task<DownloadFileModel> Download(int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            DownloadFileModel model = new DownloadFileModel();

            model.FileContent = ticket.File;

            return model;
        }

        public async Task Edit(TicketCreate model, int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            ticket.Heading = model.Heading;
            ticket.Description = model.Description;
            ticket.Type = model.Type.ToString();
            ticket.State = model.State.ToString();

            await dbContext.SaveChangesAsync();
        }

        public async Task<TicketCreate> FillModel(TicketCreate model, int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            model.Id = ticket.Id;
            model.ProjectId = ticket.ProjectId;
            model.CreatorName = ticket.CreatorEmail;
            model.Heading = ticket.Heading;
            model.Description = ticket.Description;

            return model;
        }

        public async Task<int> FindProjectId(int id)
        {
            Ticket ticket = await dbContext.Tickets.Include(x => x.Project).FirstOrDefaultAsync(x => x.Id == id);

            return ticket.ProjectId;
        }
    }
}
