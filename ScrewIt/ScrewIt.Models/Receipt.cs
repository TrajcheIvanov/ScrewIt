using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public double TotalForPayment { get; set; }

        public bool Paid { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateOfPayment { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public List<ReceiptProduct> ReceiptProducts { get; set; }

        public List<ReceiptService> ReceiptServices { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
