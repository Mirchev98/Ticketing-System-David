using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketingSystem.Data.Common;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Services.Models.Project;
using TicketingSystem.Web.Infrastructure;
using TicketingSystemDavid.ViewModels.Project;

namespace TicketingSystemDavid.Controllers
{
    [Authorize]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectServices;
        private readonly IUserService _userService;

        public ProjectController(IProjectService projectServices, IUserService userService)
        {
            _projectServices = projectServices;
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = DataConstants.AdminRoleName)]
        public IActionResult Create()
        {
            ProjectCreateViewModel model = new ProjectCreateViewModel();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _projectServices.Create(Conversions.ConvertProject(model));

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All(string searchTerm, string sortOrder, int page = 1)
        {
            var projects = await _projectServices.GetProjectsAsync(searchTerm, sortOrder, page, DataConstants.ProjectsPerPage);
            
            var model = new FindProjectsResultViewModel
            {
                TotalProjectsCount = projects.TotalProjectsCount,
                Projects = projects.Projects.Select(p =>
                Conversions.ConvertProjectAllViewModel(p))
                .ToList(),
                SearchTerm = searchTerm,
                SortOrder = sortOrder,
                CurrentPage = page
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!_userService.CheckIfUserIsAuthorized(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            ProjectDetails model = new ProjectDetails();

            await _projectServices.FillModel(model, id);


            return View(Conversions.ConvertProjectDetailsViewModel(model));
        }

        [Authorize(Roles = DataConstants.AdminRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectServices.Delete(id);

            return RedirectToAction("All");
        }
    }
}
