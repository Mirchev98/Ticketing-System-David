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
        private Conversions conversions;

        public MessageController(IMessageService messageServices, IUserService userService)
        {
            _messageServices = messageServices;
            _userService = userService;
            conversions = new Conversions();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            CreateMessageViewModel model = new CreateMessageViewModel();

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

            var uploadedFile = Request.Form.Files.GetFile("File");

            if (uploadedFile != null)
            {
                using var stream = new MemoryStream();
                await uploadedFile.CopyToAsync(stream);
                model.File = stream.ToArray();
                model.FileContent = stream.ToArray();
                model.FileName = uploadedFile.FileName;
            }

            model.TicketId = id;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _messageServices.Create(conversions.ConvertMessage(model), User.Identity.Name);

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


            CreateMessageModelService newModel = await _messageServices.FillModel(conversions.ConvertMessage(model), id);

            if (newModel == null)
            {
                return RedirectToAction("Details", "Ticket", new { id });
            }

            return View(conversions.ConvertMessageViewModel(newModel));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateMessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int ticketId = await _messageServices.FindTicket(model.Id);

            await _messageServices.Edit(conversions.ConvertMessage(model), id, User.Identity.Name);

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
