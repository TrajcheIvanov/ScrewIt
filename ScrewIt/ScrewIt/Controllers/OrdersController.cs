using Microsoft.AspNetCore.Mvc;
using ScrewIt.Services.Interfaces;
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
    }
}
