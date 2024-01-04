using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Services.Models.Message;
using TicketingSystemDavid.ViewModels.Message;

namespace TicketingSystemDavid.Controllers
{
    [Authorize]
    public class MessageController : BaseController
    {
        private readonly IMessageServices _messageServices;
        private readonly IUserService _userService;

        public MessageController(IMessageServices messageServices, IUserService userService)
        {
            _messageServices = messageServices;
            _userService = userService;

        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            CreateMessageViewModel model = new CreateMessageViewModel();

            model.Creator = this.User.Identity.Name;
            model.TicketId = id;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageViewModel model, int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            if (model.File != null && model.File.Length > 0)
            {
                using var stream = new MemoryStream();
                await model.File.CopyToAsync(stream);
                model.FileContent = stream.ToArray();
                model.ContentType = model.File.ContentType;
                model.FileName = model.File.FileName;
            }

            model.Creator = User.Identity.Name;
            model.TicketId = id;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _messageServices.Create(ConvertMessage(model));

            return RedirectToAction("Details", "Ticket", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            CreateMessageViewModel model = new CreateMessageViewModel();
            model.Creator = this.User.Identity.Name;

            CreateMessageModelServices newModel = await _messageServices.FillModel(ConvertMessage(model), id);

            if (newModel == null)
            {
                return RedirectToAction("Details", "Ticket", new { id });
            }

            return View(ConvertMessageViewModel(newModel));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateMessageViewModel model)
        {
            model.Creator = this.User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int ticketId = await _messageServices.FindTicket(model.Id);

            await _messageServices.Edit(ConvertMessage(model), id);

            return RedirectToAction("Details", "Ticket", new { id = ticketId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            int ticketId = await _messageServices.FindTicket(id);

            if (ticketId == null)
            {
                return RedirectToAction("All", "Project");
            }

            await _messageServices.Delete(id);

            return RedirectToAction("Details", "Ticket", new { id = ticketId });
        }

        public async Task<IActionResult> DownloadFile(int id)
        {
            var model = await _messageServices.Download(id);

            if (model == null || model.FileContent == null)
                return RedirectToAction("Details", "Ticket", new { id });

            return File(model.FileContent, model.ContentType, model.FileName);
        }
    }
}
