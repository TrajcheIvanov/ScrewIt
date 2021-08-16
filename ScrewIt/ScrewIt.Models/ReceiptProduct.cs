using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Models
{
    public class ReceiptProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ReceiptId { get; set; }

        public Receipt Receipt { get; set; }
    }
}
