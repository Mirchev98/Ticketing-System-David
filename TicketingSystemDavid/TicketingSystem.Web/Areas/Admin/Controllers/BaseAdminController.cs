using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Data.Common;

namespace TicketingSystemDavid.Web.Areas.Admin.Controllers
{
    [Area(DataConstants.AdminRoleName)]
    [Authorize(Roles = DataConstants.AdminRoleName)]
    public class BaseAdminController : Controller
    {

    }
}


