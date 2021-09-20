using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScrewIt.Repositories
{
    public class ReceiptItemsRepository : BaseRepository<ReceiptItem> , IReceiptItemsRepository
    {
        public ReceiptItemsRepository(ScrewItDbContext context) : base(context)
        {

        }

        public List<ReceiptItem> getItemsForOrder(int id)
        {
            return _context.ReceiptItems.Where(x => x.OrderId == id).ToList();
        }
    }
}
