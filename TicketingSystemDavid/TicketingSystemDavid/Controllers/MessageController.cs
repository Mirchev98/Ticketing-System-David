using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Data.Interfaces;
using TicketingSystemDavid.ViewModels.Message;

namespace TicketingSystemDavid.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IMessageServices _messageServices;

        public MessageController(IMessageServices messageServices)
        {
            _messageServices = messageServices;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            CreateMessageViewModel model = new CreateMessageViewModel();

            model.Creator = this.User.Identity.Name;
            model.TicketId = id;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageViewModel model, int id)
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
            model.TicketId = id;

            await _messageServices.Create(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CreateMessageViewModel model = new CreateMessageViewModel();
            model.Creator = this.User.Identity.Name;

            await _messageServices.FillModel(model, id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateMessageViewModel model)
        {
            model.Creator = this.User.Identity.Name;
            await _messageServices.Edit(model, id);

            return RedirectToAction("Details", "Ticket", new { id });
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
