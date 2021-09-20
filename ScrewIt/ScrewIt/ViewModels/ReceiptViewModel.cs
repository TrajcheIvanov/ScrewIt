using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }

        public double TotalForPayment { get; set; }

        public bool Paid { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateOfPayment { get; set; }

        public int OrderId { get; set; }

        public string EmplyeeId { get; set; }

    }
}
