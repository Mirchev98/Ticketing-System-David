using TicketingSystem.Services.Models.User;
using TicketingSystemDavid.ViewModels.User;

namespace TicketingSystem.Web.Areas.Admin.Infrastructure
{
    public static class Conversions
    {
        public static UserInformationServices Convert(RegisterFormModel model)
        {
            UserInformationServices newModel = new UserInformationServices
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
