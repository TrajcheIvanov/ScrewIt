using Microsoft.EntityFrameworkCore;
using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScrewIt.Repositories
{
    public class OrdersRepository : BaseRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(ScrewItDbContext context) : base(context)
        {

        }

        public override List<Order> GetAll()
        {
            return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Panel)
                .ToList();
        }

        public override Order GetById(int entityId)
        {
            return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Panel)
                .Include(x => x.Dimensions)
                .FirstOrDefault(x => x.Id == entityId);
        }

        public List<Order> GetOrdersForUser(string userId)
        {
            return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Panel)
                .Where(x => x.UserId == userId).ToList();
        }

        public List<Order> GetOrdersWithFilter(string filter)
        {
            if(filter == "pending")
            {
                return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Panel)
                .Where(x => x.OrderStatus == OrderStatus.Pending).ToList();
            }else if(filter == "waitingForPayment")
            {
                return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Panel)
                .Where(x => x.OrderStatus == OrderStatus.WaitingForPayment).ToList();
            }
            else if (filter == "paid")
            {
                return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Panel)
                .Where(x => x.OrderStatus == OrderStatus.Paid).ToList();
            }
            else if (filter == "processingByProduction")
            {
                return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Panel)
                .Where(x => x.OrderStatus == OrderStatus.ProcessingByProduction).ToList();
            }
            else
            {
                return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Panel)
                .Where(x => x.OrderStatus == OrderStatus.Completed).ToList();
            }
        }

        public List<Order> GetPendingOrders()
        {
            return _context.Orders
                .Include(x => x.User)
                .Include(x => x.Panel)
                .Where(x => x.OrderStatus == OrderStatus.Pending).ToList();
        }
    }
}
