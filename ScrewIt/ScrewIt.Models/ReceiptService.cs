using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Models
{
    public class ReceiptService
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public int ReceiptId { get; set; }

        public Receipt Receipt { get; set; }
    }
}
