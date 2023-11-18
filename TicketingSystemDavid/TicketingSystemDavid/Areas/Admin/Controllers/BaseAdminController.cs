using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Common;
using TicketingSystem.Services.Models.User;
using TicketingSystemDavid.ViewModels.User;

namespace TicketingSystemDavid.Web.Areas.Admin.Controllers
{
    [Area(DataConstants.AdminRoleName)]
    [Authorize(Roles = DataConstants.AdminRoleName)]
    public class BaseAdminController : Controller
    {
        public UserInformationServices Convert(RegisterFormModel model)
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


