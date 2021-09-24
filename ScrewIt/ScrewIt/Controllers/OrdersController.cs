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
    //[Authorize]
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

        public IActionResult ManageOverview(string filter, string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;

            var orders = new List<Order>();

            if(filter == null)
            {
                orders = _ordersService.GetPendingOrders();
                
            }
            else
            {
                orders = _ordersService.GetOrdersWithFilter(filter);
                
            }

            var ordersToView = orders.Select(x => x.ToOrderViewModel()).ToList();

            return View(ordersToView);
        }

        public IActionResult Delete(int id)
        {
            var response = _ordersService.Delete(id);

            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = response.Message });
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
            }
        }

        public IActionResult Details(int id)
        {
            var order = _ordersService.GetOrderById(id);
            var orderToView = order.ToOrderViewModel();

            ViewBag.Dimensions = order.Dimensions.Select(x => x.ToDimensionViewModel()).ToList();

            if(order.OrderStatus == OrderStatus.Pending)
            {
                return View(orderToView);
            }
            else
            {
                return RedirectToAction("Details", "Receipts", new { orderId = id});
            }

        }

        public IActionResult OrdersStatus()
        {
            var userId = _userManager.GetUserId(User);
            var orders = _ordersService.GetOrdersForUser(userId);
            var ordersToView = orders.Select(x => x.ToOrderViewModel()).ToList();

            return View(ordersToView);
        }

        
        public IActionResult CheckOrderStatusWithCode(string orderCode)
        {
            var order = _ordersService.GetOrderByCode(orderCode);

            if(order == null)
            {
                ViewBag.OrderCode = orderCode;
                return View();
            } else
            {
                return View(order.ToOrderViewModel());
            }
        }
    }
}
