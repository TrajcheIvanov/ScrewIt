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
    public class PanelsController : Controller
    {
        private readonly IPanelsService _panelsService;

        public PanelsController(IPanelsService panelsService)
        {
            _panelsService = panelsService;
        }
        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;

            var panels = _panelsService.GetAll();
            var panelsToView = panels.Select(x => x.ToViewModel());

            return View(panelsToView);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(PanelCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var domainModel = model.ToPanelModel();
                var response = _panelsService.CreatePanel(domainModel);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageOverview", new { SuccessMessage = response.Message });
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = "Something went wrong... please try again" });
                }
            } else
            {
                return View(model);
            }
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var user = _panelsService.GetById(id);

            if (user != null)
            {
                var userToEdit = user.ToViewModel();

                return View(userToEdit);
            }

            return RedirectToAction("ManageOverview", new { ErrorMessage = "Something went wrong... please try again" });

        }
    }
}
