using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class DimensionCreateRequestModel
    {
        [Required]
        public int FirstDimension { get; set; }

        [Required]
        public int SecondDimension { get; set; }

        [Required]
        public int Quantity { get; set; }

        public bool Rotation { get; set; }

        public int FirstDimFirstEdge { get; set; }

        public int FirstDimSecondEdge { get; set; }

        public int SecondDimFirstEdge { get; set; }

        public int SecondDimSecondEdge { get; set; }

        public string AdditionalProcessing { get; set; }

        [Required]
        public int OrderId { get; set; }
    }
}
