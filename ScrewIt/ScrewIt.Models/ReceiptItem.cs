using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Models
{
    public class ReceiptItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int SoldProduct { get; set; }

        public double Quantity { get; set; }

        public double TotalPrice { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

     
    }
}
