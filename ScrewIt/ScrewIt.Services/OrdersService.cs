using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services.DtoModels;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public AddOrderResponse CreateOrder(Order domainModel)
        {
            var response = new AddOrderResponse();

            var newOrder = new Order()
            {
                Username = domainModel.Username,
                Material = domainModel.Material,
                DateCreated = DateTime.Now,
                OrderStatus = OrderStatus.Pending
            };

            _ordersRepository.Add(newOrder);

            response.Order = newOrder;

            return response;
        }

        public Order GetOrderById(int orderId)
        {
            return _ordersRepository.GetById(orderId);
        }
    }
}

