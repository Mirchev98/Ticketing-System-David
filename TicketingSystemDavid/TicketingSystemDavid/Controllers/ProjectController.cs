﻿using Microsoft.AspNetCore.Mvc;
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

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProjectAllQueryModel query)
        {
            AllProjectsFilteredAndOrdered model = await _projectServices.AllAsync(query);

            query.Projects = model.Projects;
            query.TotalProjects = model.TotalProjectsCount;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ProjectDetailsViewModel model = new ProjectDetailsViewModel();

            await _projectServices.FillModel(model, id);

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _projectServices.Delete(id);

            return RedirectToAction("All");
        }
    }
}
