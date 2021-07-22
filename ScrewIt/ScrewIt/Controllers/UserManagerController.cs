using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScrewIt.Common;
using ScrewIt.Mappings;
using ScrewIt.Models;
using ScrewIt.Repositories;
using ScrewIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.Controllers
{
    public class UserManagerController : Controller
    {
        private readonly ScrewItDbContext _db;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;


        public UserManagerController(
            ScrewItDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;

            var users = _userManager.Users.ToList();
            var usersToViewModel = new List<UserViewModel>();

            foreach (var user in users)
            {
                var role = _db.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
                var roleName = "";

                if (role == null)
                {
                    roleName = Helper.Customer;
                } else
                {
                    roleName = _db.Roles.FirstOrDefault(x => x.Id == role.RoleId).Name;
                }


                usersToViewModel.Add(user.ToViewModel(roleName));
            }

            return View(usersToViewModel);
        }

        [HttpGet]
        public IActionResult getUsers(string filterCriteria)
        {
            var searchCriteria = _userManager.Users;

            if(filterCriteria != null)
            {
                searchCriteria = _userManager.Users.Where(x => x.Name.Contains(filterCriteria));
            }

            var users = searchCriteria.ToList();
                
            var usersToViewModel = new List<UserViewModel>();

            foreach (var user in users)
            {
                var role = _db.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
                var roleName = _db.Roles.FirstOrDefault(x => x.Id == role.RoleId);

                usersToViewModel.Add(user.ToViewModel(roleName.Name));
            }

            return Ok(usersToViewModel);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            var role = _db.UserRoles.FirstOrDefault(x => x.UserId == user.Id);

            var roleName = _db.Roles.FirstOrDefault(x => x.Id == role.RoleId);

            var userToEdit = user.ToViewModel(roleName.Name);

            return View(userToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel userForUpdate)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userForUpdate.Id);
            var role = _db.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
            var roleName = _db.Roles.FirstOrDefault(x => x.Id == role.RoleId);

            if (userForUpdate.RoleName != roleName.ToString()) 
            {
                _db.UserRoles.Remove(role);
                var roleToAdd = _db.Roles.FirstOrDefault(x => x.Name == userForUpdate.RoleName);
                await _userManager.AddToRoleAsync(user, roleToAdd.Name);
            }
            
            user.Name = userForUpdate.Name;
            user.Surname = userForUpdate.Surname;
            user.Email = userForUpdate.Email;
            user.PhoneNumber = userForUpdate.PhoneNumber;

            await _userManager.UpdateAsync(user);


            return RedirectToAction("ManageOverview", new { SuccessMessage = "User " + user.Name + " edited sucessfully" });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            var userName = user.UserName;
            await _userManager.DeleteAsync(user);

            return RedirectToAction("ManageOverview" , new { ErrorMessage = "User " + userName + " deleted sucessfully" });
        }
    }
}
