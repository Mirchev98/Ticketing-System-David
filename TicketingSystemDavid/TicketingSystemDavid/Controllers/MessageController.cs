using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Data.Models;
using TicketingSystem.Web.ViewModels.Message;
using TitcketingSystem.Data.Interfaces;

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
            model.Creator = this.User.Identity.Name;
            model.TicketId = id;

            await _messageServices.Create(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
