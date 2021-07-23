using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class PanelCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public double Thickness { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
