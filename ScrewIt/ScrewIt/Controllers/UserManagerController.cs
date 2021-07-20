using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult ManageOverview()
        {
            var users = _userManager.Users.ToList();
            var usersToViewModel = new List<UserViewModel>();

            foreach (var user in users)
            {
                var role = _db.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
                var roleName = _db.Roles.FirstOrDefault(x => x.Id == role.RoleId);

                usersToViewModel.Add(user.ToViewModel(roleName.Name));
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
    }
}
