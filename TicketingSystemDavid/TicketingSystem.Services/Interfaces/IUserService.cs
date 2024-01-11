using TicketingSystem.Data.Models;
using TicketingSystem.Services.Models.User;

namespace TicketingSystem.Services.Interfaces
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

        Task Edit(ApplicationUser user, UserInformationServices model);

        bool CheckIfUserIsAuthorized(string id);

        string GetUserId(string email);
    }
}
