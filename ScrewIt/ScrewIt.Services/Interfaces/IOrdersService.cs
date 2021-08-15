using ScrewIt.Models;
using ScrewIt.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services.Interfaces
{
    public interface IOrdersService
    {
        AddOrderResponse CreateOrder(Order domainModel);
        Order GetOrderById(int orderId);
        List<Order> GetPendingOrders();
        StatusModel Delete(int id);
    }
}
