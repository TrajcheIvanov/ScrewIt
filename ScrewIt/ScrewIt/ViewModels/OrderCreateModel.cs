using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class OrderCreateModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string OrderDescription { get; set; }

        public int PanelId { get; set; }


    }
}
