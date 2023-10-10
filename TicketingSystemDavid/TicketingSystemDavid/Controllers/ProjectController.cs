using Microsoft.AspNetCore.Mvc;

namespace TicketingSystemDavid.Controllers
{
    public class ProjectController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
