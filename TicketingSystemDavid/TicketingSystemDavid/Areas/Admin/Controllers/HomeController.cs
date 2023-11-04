using Microsoft.AspNetCore.Mvc;

namespace TicketingSystem.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
