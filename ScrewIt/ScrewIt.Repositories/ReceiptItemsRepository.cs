using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories
{
    public class ReceiptItemsRepository : BaseRepository<ReceiptItem> , IReceiptItemsRepository
    {
        public ReceiptItemsRepository(ScrewItDbContext context) : base(context)
        {

        }
    }
}
