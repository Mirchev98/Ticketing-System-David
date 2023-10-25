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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            TicketDetailsViewModel model = new TicketDetailsViewModel();

            await _ticketServices.Details(model, id);
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CreateTicketViewModel model = new CreateTicketViewModel();

            model.Creator = User.Identity.Name;

            await _ticketServices.FillModel(model, id);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateTicketViewModel model)
        {
            model.Creator = User.Identity.Name;

            await _ticketServices.Edit(model, id);

            return RedirectToAction("Details", "Ticket", new { id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _ticketServices.Delete(id);

            return RedirectToAction("All", "Project");
        }
    }
}
