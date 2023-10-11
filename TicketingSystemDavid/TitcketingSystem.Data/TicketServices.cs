using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Data.Models;
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

            await dbContext.Tickets.AddAsync(ticket);
            await dbContext.SaveChangesAsync();
        }
    }
}
