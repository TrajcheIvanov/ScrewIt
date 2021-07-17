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
    public class DimensionController : Controller
    {
        private readonly IDimensionsService _dimensionsService;

        public DimensionController(IDimensionsService dimensionsService)
        {
            dimensionsService = _dimensionsService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] DimensionCreateRequestModel dimensionCreateModel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = dimensionCreateModel.ToDimensionModel();


            }

            return Ok();
        }
    }
}
