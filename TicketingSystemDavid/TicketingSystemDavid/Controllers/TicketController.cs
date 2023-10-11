using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Web.ViewModels.Ticket;
using TitcketingSystem.Data.Interfaces;

namespace TicketingSystemDavid.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketServices _ticketServices;

        public TicketController(ITicketServices ticketServices)
        {
            this._ticketServices = ticketServices;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            CreateTicketViewModel model = new CreateTicketViewModel();

            model.ProjectId = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketViewModel model, int id)
        {
            model.Creator = this.User.Identity.Name;

            model.ProjectId = id;

            await _ticketServices.Create(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
