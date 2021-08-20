using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class ReceiptCreateModel
    {
        public double TotalForPayment { get; set; }

        public int OrderId { get; set; }

        public string EmployeeId { get; set; }
    }
}
