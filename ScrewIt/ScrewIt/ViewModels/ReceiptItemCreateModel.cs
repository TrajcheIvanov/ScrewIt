using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class ReceiptItemCreateModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int SoldProduct { get; set; }

        public double Quantity { get; set; }

        public double TotalPrice { get; set; }

        public int OrderId { get; set; }

    }
}
