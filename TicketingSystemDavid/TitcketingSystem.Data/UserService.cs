using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Data;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.ViewModels.User;
using TitcketingSystem.Data.Interfaces;

namespace TitcketingSystem.Data
{
    public class UserService : IUserService
    {
        private readonly TicketingSystemDbContext dbContext;

        public UserService(TicketingSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public Task Edit(string id, UserCredentialsEditModel model)
        {
            throw new NotImplementedException();
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
