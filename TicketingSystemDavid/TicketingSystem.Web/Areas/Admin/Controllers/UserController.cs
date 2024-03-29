﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Data.Models;
using TicketingSystemDavid.Web.Areas.Admin.Controllers;
using TicketingSystemDavid.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using TicketingSystem.Data.Common;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.Web.Areas.Admin.Infrastructure;

namespace TicketingSystemDavid.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [Route("Admin/User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<ApplicationUser> users = await userService.GetAllUsers();

            IEnumerable <ApplicationUser> filteredUsers = users.Where(x => x.Email != User.Identity.Name).ToList();

            return this.View(filteredUsers);
        }

        [Route("Admin/User/AddAdmin/{id}")]
        public async Task<IActionResult> AddAdmin(string id)
        {
            var user = await userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("All", "User");
            }

            await userManager.AddToRoleAsync(user, DataConstants.AdminRoleName);

            await userService.AddAdminRights(user);

            return RedirectToAction("All", "User");
        }

        [Route("Admin/User/RemoveAdmin/{id}")]
        public async Task<IActionResult> RemoveAdmin(string id)
        {
            var user = await userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("All", "User");
            }

            await userManager.RemoveFromRoleAsync(user, DataConstants.AdminRoleName);

            await userService.RemoveAdminRights(user);

            return RedirectToAction("All", "User");
        }

        [Route("Admin/User/AddAutorization/{id}")]
        public async Task<IActionResult> AddAutorization(string id)
        {
            var user = await userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("All", "User");
            }

            await userService.Autorize(user);

            return RedirectToAction("All", "User");
        }

        [Route("Admin/User/RemoveAutorization/{id}")]
        public async Task<IActionResult> RemoveAutorization(string id)
        {
            var user = await userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("All", "User");
            }

            await userService.RemoveAutorization(user);

            return RedirectToAction("All", "User");
        }

        [Route("Admin/User/AddSupport/{id}")]
        public async Task<IActionResult> AddSupport(string id)
        {
            var user = await userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("All", "User");
            }

            await userService.MakeSupport(user);

            return RedirectToAction("All", "User");
        }

        [Route("Admin/User/RemoveSupport/{id}")]
        public async Task<IActionResult> RemoveSupport(string id)
        {
            var user = await userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("All", "User");
            }

            await userService.RemoveSupport(user);

            return RedirectToAction("All", "User");
        }

        [HttpGet]
        [Route("Admin/User/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            RegisterUserViewModel model = new RegisterUserViewModel();

            ApplicationUser user = await userService.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("All", "User");
            }

            model.Email = user.Email;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;

            return View(model);
        }

        [HttpPost]
        [Route("Admin/User/Edit/{id}")]
        public async Task<IActionResult> Edit(string id, RegisterUserViewModel model)
        {
            ApplicationUser user = await userService.GetUserById(id);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await userService.Edit(user, Conversions.Convert(model));

            return RedirectToAction("All", "User");
        }

        [HttpGet]
        [Route("Admin/User/Register")] 
        public IActionResult Register()
        {
            var model = new RegisterUserViewModel();

            return View(model);
        }

        [HttpPost]
        [Route("Admin/User/Register")]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await userManager.SetEmailAsync(user, model.Email);
            await userManager.SetUserNameAsync(user, model.Email);

            IdentityResult result =
                await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
