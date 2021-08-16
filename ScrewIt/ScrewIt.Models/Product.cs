using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public ProductType ProductType { get; set; }

        public MeasureUnit MeasureUnit { get; set; }

        public List<ReceiptProduct> ReceiptProducts { get; set; }
    }
}
