using Microsoft.AspNetCore.Mvc;

namespace TicketingSystemDavid.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
