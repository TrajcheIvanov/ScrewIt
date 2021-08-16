using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class ProductCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public MeasureUnit MeasureUnit { get; set; }
    }
}
