using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketingSystem.Data.Interfaces;
using TicketingSystem.Services.Models.Ticket;
using TicketingSystem.Services.Models.User;
using TicketingSystemDavid.ViewModels.Ticket;

namespace TicketingSystemDavid.Controllers
{
    [Authorize]
    public class TicketController : BaseController
    {
        private readonly ITicketServices _ticketServices;
        private readonly IUserService _userService;

        public TicketController(ITicketServices ticketServices, IUserService userServices)
        {
            this._ticketServices = ticketServices;
            this._userService = userServices;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {

            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

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

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _ticketServices.Create(ConvertTicket(model));

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            TicketDetailsViewModelServices model = new TicketDetailsViewModelServices();

            await _ticketServices.Details(model, id);

            return View(ConvertTicketDetailsViewModel(model));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CreateTicketViewModelServices model = new CreateTicketViewModelServices();

            model.Creator = User.Identity.Name;

            await _ticketServices.FillModel(model, id);

            return View(ConvertTicketViewModel(model));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateTicketViewModel model)
        {
            model.Creator = User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _ticketServices.Edit(ConvertTicket(model), id);

            return RedirectToAction("Details", "Ticket", new { id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _ticketServices.Delete(id);

            return RedirectToAction("All", "Project");
        }

        public async Task<IActionResult> DownloadFile(int id)
        {
            var model = await _ticketServices.Download(id);

            if (model == null || model.FileContent == null)
                return RedirectToAction("Details", "Ticket", new { id });

            return File(model.FileContent, model.ContentType, model.FileName);
        }
    }
}
