using ScrewIt.Services.Interfaces;
using ScrewIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ScrewIt.Services.DtoModels;
using ScrewIt.Models;

namespace ScrewIt.Services
{
    public class ReceiptItemsService : IReceiptItemsService
    {
        private readonly IReceiptItemsRepository _receiptItemsRepositry;
        private readonly IOrdersRepository _ordersRepository;

        public ReceiptItemsService(
            IReceiptItemsRepository receiptItemsRepositry,
            IOrdersRepository ordersRepository)
        {
            _receiptItemsRepositry = receiptItemsRepositry;
            _ordersRepository = ordersRepository;
        }

        public AddReceiptItemResponse Create(ReceiptItem receiptItem)
        {
            var response = new AddReceiptItemResponse();

            var order = _ordersRepository.GetById(receiptItem.OrderId);

            if (order == null)
            {
                response.Status.IsSuccessful = false;
            }
            else
            {
                order.OrderStatus = OrderStatus.WaitingForPayment;
                _receiptItemsRepositry.Add(receiptItem);
                response.ReceiptItem = _receiptItemsRepositry.GetById(receiptItem.Id);
            }

            return response;
        }
    }
}
