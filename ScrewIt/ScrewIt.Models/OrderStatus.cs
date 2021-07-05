using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Models
{
    public enum OrderStatus
    {
        Pending,
        ProcessingBySales,
        ProcessingByProduction,
        Completed
    }
}
