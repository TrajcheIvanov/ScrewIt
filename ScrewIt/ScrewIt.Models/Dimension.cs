﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Models
{
    public class Dimension
    {
        public int Id { get; set; }

        public int FirstDimension { get; set; }

        public int SecondDimension { get; set; }

        public int Quantity { get; set; }

        public bool Rotation { get; set; }

        public int FirstDimFirstEdge { get; set; }

        public int FirstDimSecondEdge { get; set; }

        public int SecondDimFirstEdge { get; set; }

        public int SecondDimSecondEdge { get; set; }

        public string AdditionalProcessing { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

    }
}
