using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Web.ViewModels.Ticket;

namespace TitcketingSystem.Data.Interfaces
{
    public interface ITicketServices
    {
        Task Create(CreateTicketViewModel model); 
    }
}
