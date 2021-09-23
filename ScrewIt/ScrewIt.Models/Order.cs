using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScrewIt.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateToBeCompleted { get; set; }

        public string OrderCode { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<Dimension> Dimensions { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
     
        public string OrderDescription { get; set; }

        public int PanelId { get; set; }
        public Panel Panel { get; set; }
    }
}
