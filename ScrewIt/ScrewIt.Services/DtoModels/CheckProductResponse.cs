using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services.DtoModels
{
    public class CheckProductResponse
    {
        public StatusModel Status { get; set; } = new StatusModel();

        public int ProductId { get; set; }

        public string Type { get; set; }
    }
}
