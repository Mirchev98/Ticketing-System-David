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

        Task<TicketDetailsViewModel> Details(TicketDetailsViewModel model, int id);

        Task<CreateTicketViewModel> FillModel(CreateTicketViewModel model, int id);

        Task Edit(CreateTicketViewModel model, int id);

        Task Delete(int id);
    }
}
