using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Order-Id")]
        public int Id { get; set; }

        [Display(Name = "Customer-Name")]
        public string Username { get; set; }

        [Display(Name = "Order-Description")]
        public string OrderDescription { get; set; }

        [Display(Name = "Panel-Info")]
        public string PanelName { get; set; }
    }
}
