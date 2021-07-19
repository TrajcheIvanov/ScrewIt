using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class DimensionController : Controller
    {
        private readonly IDimensionsService _dimensionsService;

        public DimensionController(IDimensionsService dimensionsService)
        {
            _dimensionsService = dimensionsService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]DimensionCreateRequestModel dimensionCreateModel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = dimensionCreateModel.ToDimensionModel();
                var response = _dimensionsService.CreateDimension(domainModel);

                if (response.IsSuccessful)
                {
                    return Ok(new { Message = response.Message });
                }
                else
                {
                    return BadRequest(new { Message = response.Message });
                }

            }

            return BadRequest(new { Message = "Oops! Something went wrong" });
        }
    }
}
