﻿using Microsoft.AspNetCore.Mvc;

namespace TicketingSystemDavid.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
