using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;
using TicketingSystem.Data.Models;
using TicketingSystem.Data.Interfaces;

namespace TicketingSystem.Data
{
    public class UserService : IUserService
    {
        private readonly TicketingSystemDbContext dbContext;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(TicketingSystemDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task AddAdminRights(ApplicationUser user)
        {
            user.IsAdmin = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task Autorize(ApplicationUser user)
        {
            user.IsAuthorized = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task Edit(ApplicationUser user, RegisterFormModel model)
        {
            user.Email = model.Email;
            user.NormalizedEmail = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PasswordHash = Crypto.HashPassword(model.Password);

            await userManager.SetEmailAsync(user, model.Email);
            await userManager.SetUserNameAsync(user, model.Email);

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            List<ApplicationUser> users = await dbContext.Users.ToListAsync();

            return users;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            ApplicationUser? user = await dbContext.Users.FindAsync(id);

            return user;
        }

        public async Task MakeSupport(ApplicationUser user)
        {
            user.IsSupport = true;
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAdminRights(ApplicationUser user)
        {
            user.IsAdmin = false;
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAutorization(ApplicationUser user)
        {
            user.IsAuthorized = false;
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveSupport(ApplicationUser user)
        {
            user.IsSupport = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
