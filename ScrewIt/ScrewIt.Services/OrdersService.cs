using Microsoft.AspNetCore.Identity;
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
                UserId = domainModel.UserId,
                OrderDescription = domainModel.OrderDescription,
                PanelId = domainModel.PanelId,
                DateCreated = DateTime.Now,
                OrderStatus = OrderStatus.Pending
            };

            _ordersRepository.Add(newOrder);

            response.Order = _ordersRepository.GetById(newOrder.Id);

            return response;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var order = _ordersRepository.GetById(id);

            if (order == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The Order with id {id} was not found";
            }
            else
            {
                _ordersRepository.Delete(order);
                response.Message = $"The Order with description {order.OrderDescription} was deleted";
            }

            return response;
        }

        public Order GetOrderById(int orderId)
        {
            return _ordersRepository.GetById(orderId);
        }

        public List<Order> GetOrdersForUser(string userId)
        {
            return _ordersRepository.GetOrdersForUser(userId);
        }

        public List<Order> GetOrdersWithFilter(string filter)
        {
            return _ordersRepository.GetOrdersWithFilter(filter);
        }

        public List<Order> GetPendingOrders()
        {
            return _ordersRepository.GetPendingOrders();
        }
    }
}

