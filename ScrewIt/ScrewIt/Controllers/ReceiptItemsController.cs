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
    public class ReceiptItemsController : Controller
    {
        private readonly IReceiptItemsService _receiptItemsService;
        
        public ReceiptItemsController(IReceiptItemsService receiptItemsService)
        {
            _receiptItemsService = receiptItemsService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReceiptItemCreateModel receipt)
        {
            var receiptItem = new ReceiptItem()
            {
                Name = receipt.Name,
                Price = receipt.Price,
                Type = receipt.Type,
                SoldProduct = receipt.SoldProduct,
                Quantity = receipt.Quantity,
                TotalPrice = receipt.TotalPrice,
                OrderId = receipt.OrderId,

            };

            var response = _receiptItemsService.Create(receiptItem);

            if (response.Status.IsSuccessful)
            {
                return Ok(response.ReceiptItem.Id);
            }
            else
            {
                return BadRequest(new { Message = response.Status.Message });
            }
        }
    }
}
