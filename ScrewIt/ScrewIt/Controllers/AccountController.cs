﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScrewIt.Common;
using ScrewIt.Models;
using ScrewIt.ViewModels;
using System.Threading.Tasks;

namespace ScrewIt.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Overview", "Home");
                }
                ModelState.AddModelError("", "Invalid login attepmt");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.ContentCreator));
                await _roleManager.CreateAsync(new IdentityRole(Helper.CustomerSupport));
                await _roleManager.CreateAsync(new IdentityRole(Helper.ProductionEmploye));
                await _roleManager.CreateAsync(new IdentityRole(Helper.ProductionManager));
                await _roleManager.CreateAsync(new IdentityRole(Helper.SalesManager));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Customer));

            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Helper.Customer);

                    return RedirectToAction("Overview", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            var user = User;

            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Account");
        }
    }
}
