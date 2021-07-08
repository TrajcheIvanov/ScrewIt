﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.ViewModels
{
    public class OrderCreateModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Material { get; set; }

        public DimensionModel Dimension { get; set; }

    }
}
