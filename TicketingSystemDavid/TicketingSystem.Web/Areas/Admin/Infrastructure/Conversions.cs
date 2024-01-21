using TicketingSystem.Services.Models.User;
using TicketingSystemDavid.ViewModels.User;

namespace TicketingSystem.Web.Areas.Admin.Infrastructure
{
    public static class Conversions
    {
        public static UserInformation Convert(RegisterUserViewModel model)
        {
            UserInformation newModel = new UserInformation
            {
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            return newModel;
        }
    }
}
