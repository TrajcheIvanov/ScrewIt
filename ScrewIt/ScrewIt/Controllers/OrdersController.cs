using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScrewIt.Mappings;
using ScrewIt.Models;
using ScrewIt.Services.Interfaces;
using ScrewIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {

        private readonly IOrdersService _ordersService;
        private readonly IPanelsService _panelsService;
        UserManager<ApplicationUser> _userManager;


        public OrdersController(
            IOrdersService ordersService,
            IPanelsService panelsService,
            UserManager<ApplicationUser> userManager
            )
        {
            _ordersService = ordersService;
            _panelsService = panelsService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var orderCreateModel = new OrderCreateModel();
            var panels = _panelsService.GetAll();
            var panelsToView = panels.Select(x => x.ToViewModel()).ToList();
            ViewBag.Panels = panelsToView;

            //orderCreateModel.Panels = panelsToView;

            var id = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(id);

            ViewBag.Username = user.Name;
            ViewBag.UserId = user.Id;

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderCreateModel orderCreateModel)
        //public IActionResult Create(OrderCreateModel orderCreateModel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = orderCreateModel.ToOrderModel();
                var response = _ordersService.CreateOrder(domainModel);

                if (response.Status.IsSuccessful)
                {
                    return Ok(response.Order.ToOrderViewModel());
                }
                else
                {
                    return BadRequest(new { Message = response.Status.Message });
                }
            }
            
            return View(orderCreateModel);
        }
    }
}
