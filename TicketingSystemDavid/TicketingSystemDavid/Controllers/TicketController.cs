using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Web.ViewModels.Ticket;
using TitcketingSystem.Data;
using TitcketingSystem.Data.Interfaces;

namespace TicketingSystem.Controllers
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
            if (model.File != null && model.File.Length > 0)
            {
                using var stream = new MemoryStream();
                await model.File.CopyToAsync(stream);
                model.FileContent = stream.ToArray();
                model.ContentType = model.File.ContentType;
                model.FileName = model.File.FileName;
            }

            
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

        public async Task<IActionResult> DownloadFile(int id)
        {
            var ticket = await _ticketServices.Find(id);

            if (ticket == null || ticket.FileContent == null)
                return RedirectToAction("Details", "Ticket", new { id });

            return File(ticket.FileContent, ticket.ContentType, ticket.FileName);
        }
    }
}
