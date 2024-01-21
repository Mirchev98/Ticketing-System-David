using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Data.Common;
using TicketingSystem.Services.Models.User;
using TicketingSystemDavid.ViewModels.User;

namespace TicketingSystemDavid.Web.Areas.Admin.Controllers
{
    [Area(DataConstants.AdminRoleName)]
    [Authorize(Roles = DataConstants.AdminRoleName)]
    public class BaseAdminController : Controller
    {

    }
}


