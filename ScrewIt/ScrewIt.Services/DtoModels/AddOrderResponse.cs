using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services.DtoModels
{
    public class AddOrderResponse
    {
        public StatusModel Status { get; set; } = new StatusModel();

        public Order Order { get; set; }
    }
}
