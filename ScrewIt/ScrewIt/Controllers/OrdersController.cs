using Microsoft.AspNetCore.Mvc;
using ScrewIt.Mappings;
using ScrewIt.Services.Interfaces;
using ScrewIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody]OrderCreateModel orderCreateModel)
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
