using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Web.ViewModels.Project;
using TitcketingSystem.Data;
using TitcketingSystem.Data.Interfaces;

namespace TicketingSystemDavid.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectServices _projectServices;

        public ProjectController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateProjectViewModel model = new CreateProjectViewModel();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel model)
        {
            await _projectServices.Create(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProjectAllQueryModel query)
        {
            AllProjectsFilteredAndOrdered model = await _projectServices.AllAsync(query);

            query.Projects = model.Projects;
            query.TotalProjects = model.TotalProjectsCount;

            return View(query);
        }
    }
}
