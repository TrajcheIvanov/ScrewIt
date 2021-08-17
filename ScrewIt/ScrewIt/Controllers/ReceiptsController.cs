using Microsoft.AspNetCore.Mvc;
using ScrewIt.Services.Interfaces;
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
            var stringToReturn = new List<String>();

            var panels = _panelsService.GetAll();

            foreach (var panel in panels)
            {
                if (panel.Name.ToLower().Contains(term.ToLower()))
                {
                    stringToReturn.Add(panel.Name);
                }
            }

            var products = _productsService.GetAll();

            foreach (var product in products)
            {
                if (product.Name.ToLower().Contains(term.ToLower()))
                {
                    stringToReturn.Add(product.Name);
                }
            }

            return stringToReturn;
        }
    }
}
