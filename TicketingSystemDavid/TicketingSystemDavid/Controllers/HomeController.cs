using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketingSystem.Common;
using TicketingSystemDavid.Models;

namespace TicketingSystemDavid.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (this.User.IsInRole(DataConstants.AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = DataConstants.AdminRoleName });
            }

            return RedirectToAction("All", "Project");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}