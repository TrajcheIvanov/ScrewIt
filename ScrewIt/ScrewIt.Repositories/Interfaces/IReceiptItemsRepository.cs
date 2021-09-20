using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories.Interfaces
{
    public interface IReceiptItemsRepository : IBaseRepository<ReceiptItem>
    {
        List<ReceiptItem> getItemsForOrder(int id);
    }
}
