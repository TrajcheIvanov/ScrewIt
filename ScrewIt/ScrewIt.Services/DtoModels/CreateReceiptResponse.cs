using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services.DtoModels
{
    public class CreateReceiptResponse
    {
        public StatusModel Status { get; set; } = new StatusModel();

        public Receipt Receipt { get; set; }
    }
}
