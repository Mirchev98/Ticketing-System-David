using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Services.Models.Message;
using TicketingSystem.Web.Infrastructure;
using TicketingSystemDavid.ViewModels.Message;

namespace TicketingSystemDavid.Controllers
{
    [Authorize]
    public class MessageController : BaseController
    {
        private readonly IMessageService _messageServices;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageServices, IUserService userService)
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

            MessageCreateViewModel model = new MessageCreateViewModel();

            model.TicketId = id;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessageCreateViewModel model, int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            model.CreatorName = this.User.Identity.Name;

            model.CreatorId = _userService.GetUserId(this.User.Identity.Name);

            var uploadedFile = Request.Form.Files.GetFile("File");

            if (uploadedFile != null)
            {
                using var stream = new MemoryStream();
                await uploadedFile.CopyToAsync(stream);
                model.File = stream.ToArray();
            }

            model.TicketId = id;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _messageServices.Create(Conversions.ConvertMessage(model));

            return RedirectToAction("Details", "Ticket", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            MessageCreateViewModel model = new MessageCreateViewModel();


            MessageCreate newModel = await _messageServices.FillModel(Conversions.ConvertMessage(model), id);

            if (newModel == null)
            {
                return RedirectToAction("Details", "Ticket", new { id });
            }

            return View(Conversions.ConvertMessageViewModel(newModel));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MessageCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int ticketId = await _messageServices.FindTicket(model.Id);

            await _messageServices.Edit(Conversions.ConvertMessage(model), id);

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

            var memory = new MemoryStream(model.FileContent);

            if (model == null || model.FileContent == null)
                return RedirectToAction("Details", "Ticket", new { id });

            return File(memory, "application/octet-stream", model.FileName);
        }
    }
}
