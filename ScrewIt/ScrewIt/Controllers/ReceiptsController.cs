using Microsoft.AspNetCore.Mvc;
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

        public ReceiptsController(
            IReceiptsService receiptsService,
            IPanelsService panelsService,
            IProductsService productsService
            )
        {
            _receiptsService = receiptsService;
            _panelsService = panelsService;
            _productsService = productsService;

        }
        public IActionResult Create()
        {
            return View();
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

        public IActionResult getProduct(string type, string id)
        {
            var productToReturn = new SoldProduct();

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
