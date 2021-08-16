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
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;

            var products = _productsService.GetAll();
            var productsToView = products.Select(x => x.ToViewModel());

            return View(productsToView);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var domainModel = model.ToModel();
                var response = _productsService.CreateProduct(domainModel);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageOverview", new { SuccessMessage = response.Message });
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = "Something went wrong... please try again" });
                }
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var product = _productsService.GetById(id);

            if (product != null)
            {
                var productToEdit = product.ToViewModel();

                return View(productToEdit);
            }

            return RedirectToAction("ManageOverview", new { ErrorMessage = "Something went wrong... please try again" });

        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var domainModel = model.ToModel();
                var response = _productsService.Update(domainModel);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageOverview", new { SuccessMessage = response.Message });
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            var response = _productsService.Delete(id);

            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = response.Message });
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
            }
        }

    }
}
