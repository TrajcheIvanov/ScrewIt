using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class PanelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Length { get; set; }

        public int Height { get; set; }

        public double Thickness { get; set; }

        public double Price { get; set; }

        public string GetFullName()
        {
            string fullName = this.Name + " - " + Convert.ToString(this.Thickness) + " - " + Convert.ToInt32(this.Length) + " x " + Convert.ToInt32(this.Height);

            return fullName;

        }

    }
}
