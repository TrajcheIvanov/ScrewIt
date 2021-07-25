using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ScrewIt.Models;
using ScrewIt.Mappings;
using ScrewIt.Repositories;
using ScrewIt.ViewModels;

namespace ScrewIt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ScrewItDbContext _db;
        UserManager<ApplicationUser> _userManager;


        public HomeController(
            UserManager<ApplicationUser> userManager,
            ScrewItDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Overview()
        {
            
            var id = _userManager.GetUserId(User);
            var userToView = new UserViewModel();

            if (id != null)
            {
                var user = await _userManager.FindByIdAsync(id);

                
                var role = _db.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
                var roleName = _db.Roles.FirstOrDefault(x => x.Id == role.RoleId);

                userToView = user.ToViewModel(roleName.Name);
            }



            return View(userToView);
        }
    }
}
