using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScrewIt.Models
{
    public enum MeasureUnit
    {
        [Display(Name = "m")]
        Meter,
        [Display(Name = "No.")]
        Number,
        [Display(Name = "PAN")]
        Panel,
        [Display(Name = "mm")]
        Milimeter
    }
}
