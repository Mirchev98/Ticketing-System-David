using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Web.ViewModels.Message;

namespace TitcketingSystem.Data.Interfaces
{
    public interface IMessageServices
    {
        Task Create(CreateMessageViewModel model);
    }
}
