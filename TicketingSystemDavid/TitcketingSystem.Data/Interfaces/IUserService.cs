using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data.Models;

namespace TitcketingSystem.Data.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserById(string id);

        Task<List<ApplicationUser>> GetAllUsers();

        Task AddAdminRights(ApplicationUser user);

        Task RemoveAdminRights(ApplicationUser user);

        Task MakeSupport(ApplicationUser user);

        Task RemoveSupport(ApplicationUser user);

        Task Autorize(ApplicationUser user);

        Task RemoveAutorization(ApplicationUser user);
    }
}
