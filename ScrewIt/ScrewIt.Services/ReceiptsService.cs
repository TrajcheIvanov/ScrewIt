using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services.DtoModels;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services
{
    public class ReceiptsService : IReceiptsService
    {

        private readonly IReceiptsRepository _receiptsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IPanelsRepository _panelsRepository;
        private readonly IOrdersRepository _ordersRepository;

        public ReceiptsService(
            IReceiptsRepository receiptsRepository,
            IProductsRepository productsRepository,
            IPanelsRepository panelsRepository,
            IOrdersRepository ordersRepository)
        {
            _receiptsRepository = receiptsRepository;
            _productsRepository = productsRepository;
            _panelsRepository = panelsRepository;
            _ordersRepository = ordersRepository;
        }

        public CheckProductResponse CheckIfProductIsValid(string product)
        {
            var response = new CheckProductResponse();


            var panelResponse = _panelsRepository.CheckIfExist(product);

            if(panelResponse == null)
            {
                var productResponse = _productsRepository.CheckIfExist(product);

                if(productResponse == null)
                {
                    response.Status.IsSuccessful = false;
                }
                else
                {
                    response.ProductId = productResponse.Id;
                    response.Type = "product";
                }
            }
            else
            {
                response.ProductId = panelResponse.Id;
                response.Type = "panel";
            }

            return response;
        }

        public CreateReceiptResponse Create(int orderId, double totalForPayment, string employeeId)
        {
            var response = new CreateReceiptResponse();

            var order = _ordersRepository.GetById(orderId);
            
            if(order == null)
            {
                response.Status.IsSuccessful = false;
            }
            else
            {
                var receipt = new Receipt()
                {
                    OrderId = orderId,
                    TotalForPayment = totalForPayment,
                    EmplyeeId = employeeId,
                    Paid = false,
                    DateCreated = DateTime.Now,
                };

                _receiptsRepository.Add(receipt);
                order.OrderStatus = OrderStatus.WaitingForPayment;
                _ordersRepository.Update(order);
                response.Receipt = _receiptsRepository.GetById(receipt.Id);
            }

            return response;
        }

        public Receipt GetByOrderId(int id)
        {
            return _receiptsRepository.GetByOrderId(id);
        }

        public List<string> GetProductOffer(string term)
        {
            var stringToReturn = new List<String>();


            var panels = _panelsRepository.GetAll();

            foreach (var panel in panels)
            {
                if (panel.Name.ToLower().Contains(term.ToLower()))
                {
                    stringToReturn.Add(panel.Name);
                }
            }

            var products = _productsRepository.GetAll();

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
