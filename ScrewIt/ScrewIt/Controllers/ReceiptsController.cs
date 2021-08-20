using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScrewIt.Models;
using ScrewIt.Services.Interfaces;
using ScrewIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService _receiptsService;
        private readonly IPanelsService _panelsService;
        private readonly IProductsService _productsService;
        UserManager<ApplicationUser> _userManager;

        public ReceiptsController(
            IReceiptsService receiptsService,
            IPanelsService panelsService,
            IProductsService productsService,
            UserManager<ApplicationUser> userManager
            )
        {
            _receiptsService = receiptsService;
            _panelsService = panelsService;
            _productsService = productsService;
            _userManager = userManager;

        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.OrderId = id;

            var userId = _userManager.GetUserId(User);
            

            if (userId != null)
            {
                ViewBag.UserId = userId;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReceiptCreateModel receipt)
        {
            var response = _receiptsService.Create(receipt.OrderId, receipt.TotalForPayment, receipt.EmployeeId);

            if (response.Status.IsSuccessful)
            {
                return Ok(response.Receipt.Id);
            }
            else
            {
                return BadRequest(new { Message = response.Status.Message });
            }
        }

        public List<String> GetForAutoCompleteProduct(String term)
        {
            var productOffer = _receiptsService.GetProductOffer(term);

            return productOffer;
        }

        public IActionResult CheckIfChosenProductIsValid(string product)
        {
            var result = _receiptsService.CheckIfProductIsValid(product);

            return Ok(result);
        }

        public IActionResult getProductToSell(string type, string id)
        {
            var productToReturn = new ProductToSell();

            if(type == "panel")
            {
                var panel = _panelsService.GetById(Convert.ToInt32(id));
                productToReturn.Id = panel.Id;
                productToReturn.Name = panel.Name;
                productToReturn.Price = panel.Price;
                productToReturn.Type = "panel";

            }
            else
            {
                var product = _productsService.GetById(Convert.ToInt32(id));
                productToReturn.Id = product.Id;
                productToReturn.Name = product.Name;
                productToReturn.Price = product.Price;
                productToReturn.Type = "product";
            }

            return Ok(productToReturn);
        }


        
    }
}
