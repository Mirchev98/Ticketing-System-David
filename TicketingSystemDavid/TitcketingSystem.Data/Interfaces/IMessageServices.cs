using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.ViewModels.Message;

namespace TitcketingSystem.Data.Interfaces
{
    public interface IMessageServices
    {
        Task Create(CreateMessageViewModel model);

        Task<CreateMessageViewModel> FillModel(CreateMessageViewModel model, int id);

        Task Edit(CreateMessageViewModel model, int id);

        Task Delete(int id);

        Task<Message> Find(int id);
    }
}
