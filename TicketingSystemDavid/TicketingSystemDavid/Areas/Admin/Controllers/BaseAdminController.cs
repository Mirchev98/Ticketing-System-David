using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketingSystem.Common;

    
namespace TicketingSystemDavid.Web.Areas.Admin.Controllers
{
    [Area(DataConstants.AdminRoleName)]
    [Authorize(Roles = DataConstants.AdminRoleName)]
    public class BaseAdminController : Controller
    {

    }
}


