using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories.Interfaces
{
    public interface IOrdersRepository : IBaseRepository<Order>
    {
        List<Order> GetPendingOrders();
        List<Order> GetOrdersWithFilter(string filter);
        List<Order> GetOrdersForUser(string userId);
    }
}
