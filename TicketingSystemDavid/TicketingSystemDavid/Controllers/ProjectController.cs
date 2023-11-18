using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Common;
using TicketingSystem.Data.Interfaces;
using TicketingSystem.Services.Models.Project;
using TicketingSystemDavid.ViewModels.Project;

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
        [Authorize(Roles = DataConstants.AdminRoleName)]
        public IActionResult Create()
        {
            CreateProjectViewModel model = new CreateProjectViewModel();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel model)
        {
            await _projectServices.Create(ConvertProject(model));

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProjectAllQueryModel query)
        {
            AllProjectsFilteredAndOrderedServices model = await _projectServices.AllAsync(ConvertQuery(query));

            AllProjectsFilteredAndOrdered convertedModel = ConvertProjectAllViewModel(model);

            query.Projects = convertedModel.Projects;
            query.TotalProjects = convertedModel.TotalProjectsCount;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ProjectDetailsViewModelServices model = new ProjectDetailsViewModelServices();

            await _projectServices.FillModel(model, id);


            return View(ConvertProjectDetailsViewModel(model));
        }

        [Authorize(Roles = DataConstants.AdminRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectServices.Delete(id);

            return RedirectToAction("All");
        }
    }
}
