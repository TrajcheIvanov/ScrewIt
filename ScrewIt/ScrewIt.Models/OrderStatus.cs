using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScrewIt.Models
{
    public enum OrderStatus
    {
        
        Pending,
        [Display(Name = "Waiting for Payment")]
        WaitingForPayment,
        [Display(Name = "Processing by Production")]
        ProcessingByProduction,
        Completed
    }
}
