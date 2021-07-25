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
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Material { get; set; }

        public int PanelId { get; set; }


    }
}
