using Microsoft.EntityFrameworkCore;
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

        public async Task Create(TicketCreateModelServices model)
        {
            Ticket ticket = new Ticket();

            ticket.ProjectId = model.ProjectId;
            ticket.CreatorEmail = model.Creator;
            ticket.State = model.State.ToString();
            ticket.Heading = model.Heading;
            ticket.Description = model.Description;
            ticket.Type = model.Type.ToString();
            ticket.FileContent = model.FileContent;
            ticket.ContentType = model.ContentType;
            ticket.FileName = model.FileName;
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

        public async Task<TicketDetailsModelServices> Details(TicketDetailsModelServices model, int id)
        {
            Ticket ticket = await dbContext.Tickets.Include(x => x.Messages).FirstOrDefaultAsync(t => t.Id == id);

            model.Id = ticket.Id;
            model.ProjectId = ticket.ProjectId;
            model.Creator = ticket.CreatorEmail;
            model.State = ticket.State;
            model.Heading = ticket.Heading;
            model.Description = ticket.Description;
            model.Type = ticket.Type;
            model.IsDeleted = ticket.SoftDeleted;
            model.FileContent = ticket.FileContent;
            model.FileName = ticket.FileName;
            model.Messages = ticket.Messages.Select(x => new MessageDetailsViewModelService
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Creator = x.CreatorEmail,
                State = (MessageStateService)Enum.Parse(typeof(MessageStateService), x.State.ToString()),
                Content = x.Content,
                TicketId = x.TicketId,
                SoftDeleted = x.SoftDeleted,
                FileContent = x.FileContent,
                FileName = x.FileName
            }).ToList();

            return model;
        }

        public async Task<DownloadFileModel> Download(int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            DownloadFileModel model = new DownloadFileModel();

            model.FileContent = ticket.FileContent;
            model.ContentType = ticket.ContentType;
            model.FileName = ticket.FileName;

            return model;
        }

        public async Task Edit(TicketCreateModelServices model, int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            //ticket.ProjectId = model.ProjectId;
            ticket.CreatorEmail = model.Creator;
            ticket.Heading = model.Heading;
            ticket.Description = model.Description;
            ticket.Type = model.Type.ToString();
            ticket.State = model.State.ToString();

            await dbContext.SaveChangesAsync();
        }

        public async Task<TicketCreateModelServices> FillModel(TicketCreateModelServices model, int id)
        {
            Ticket ticket = await dbContext.Tickets.FindAsync(id);

            model.Id = ticket.Id;
            model.ProjectId = ticket.ProjectId;
            model.Creator = ticket.CreatorEmail;
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
