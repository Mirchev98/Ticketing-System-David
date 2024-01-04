using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketingSystem.Data.Common;
using TicketingSystem.Data.Interfaces;
using TicketingSystem.Services.Models.Project;
using TicketingSystemDavid.ViewModels.Project;

namespace TicketingSystemDavid.Controllers
{
    [Authorize]
    public class ProjectController : BaseController
    {
        private readonly IProjectServices _projectServices;
        private readonly IUserService _userService;

        public ProjectController(IProjectServices projectServices, IUserService userService)
        {
            _projectServices = projectServices;
            _userService = userService;

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _projectServices.Create(ConvertProject(model));

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProjectAllQueryModel query)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            AllProjectsFilteredAndOrderedServices model = await _projectServices.AllAsync(ConvertQuery(query));

            AllProjectsFilteredAndOrdered convertedModel = ConvertProjectAllViewModel(model);

            query.Projects = convertedModel.Projects;
            query.TotalProjects = convertedModel.TotalProjectsCount;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

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
