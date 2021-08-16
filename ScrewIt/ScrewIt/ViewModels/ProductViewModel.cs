using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public ProductType ProductType { get; set; }

        public MeasureUnit MeasureUnit { get; set; }
    }
}
