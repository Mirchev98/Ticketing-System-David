using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Services.Models.Ticket;
using TicketingSystem.Web.Infrastructure;
using TicketingSystemDavid.ViewModels.Ticket;

namespace TicketingSystemDavid.Controllers
{
    [Authorize]
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketServices;
        private readonly IUserService _userService;
        private Conversions conversions;

        public TicketController(ITicketService ticketServices, IUserService userServices)
        {
            this._ticketServices = ticketServices;
            this._userService = userServices;
            conversions = new Conversions();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {

            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            TicketCreateView model = new TicketCreateView();

            model.ProjectId = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreateView model, int id)
        {
            var uploadedFile = Request.Form.Files.GetFile("File");

            if (uploadedFile != null)
            {
                using var stream = new MemoryStream();
                await uploadedFile.CopyToAsync(stream);
                model.File = stream.ToArray();
            }


            model.CreatorName = this.User.Identity.Name;

            model.CreatorId = _userService.GetUserId(this.User.Identity.Name);

            model.ProjectId = id;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _ticketServices.Create(conversions.ConvertTicket(model));

            return RedirectToAction("Details", "Project", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            TicketDetails model = new TicketDetails();

            await _ticketServices.Details(model, id);

            return View(conversions.ConvertTicketDetailsViewModel(model));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            TicketCreate model = new TicketCreate();

            await _ticketServices.FillModel(model, id);

            if (model == null)
            {
                return RedirectToAction("Details", "Ticket", new { id });
            }

            return View(conversions.ConvertTicketViewModel(model));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, TicketCreateView model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _ticketServices.Edit(conversions.ConvertTicket(model), id);

            return RedirectToAction("Details", "Ticket", new { id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            int projectId = await _ticketServices.FindProjectId(id);

            if (projectId == null)
            {
                return RedirectToAction("All", "Project");
            }

            await _ticketServices.Delete(id);

            return RedirectToAction("Details", "Project", new {id = projectId});
        }

        public async Task<IActionResult> DownloadFile(int id)
        {
            var model = await _ticketServices.Download(id);

            var memory = new MemoryStream(model.FileContent);

            if (model == null || model.FileContent == null)
                return RedirectToAction("Details", "Ticket", new { id });

            return File(memory, "application/octet-stream", model.FileName);
        }
    }
}
