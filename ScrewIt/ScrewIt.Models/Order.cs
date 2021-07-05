using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateToBeCompleted { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<Dimension> Dimensions { get; set; }

        public string Material { get; set; }
    }
}
