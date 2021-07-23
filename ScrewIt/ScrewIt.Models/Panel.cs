using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Models
{
    public class Panel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Length {get; set;}

        public int Height {get; set;}

        public double Thickness {get; set;}

        public double Price {get; set; }

        public List<Order> Orders { get; set; }

    }
}
