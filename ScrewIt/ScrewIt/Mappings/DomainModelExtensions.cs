using ScrewIt.Models;
using ScrewIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.Mappings
{
    public static class DomainModelExtensions
    {
        public static DimensionViewModel ToDimensionViewModel(this Dimension dimension)
        {
            return new DimensionViewModel()
            {
                Id = dimension.Id,
                FirstDimension = dimension.FirstDimension,
                SecondDimension = dimension.SecondDimension,
                Quantity = dimension.Quantity,
                Rotation = dimension.Rotation,
                FirstDimFirstEdge = dimension.FirstDimFirstEdge,
                FirstDimSecondEdge = dimension.FirstDimSecondEdge,
                SecondDimFirstEdge = dimension.SecondDimFirstEdge,
                SecondDimSecondEdge = dimension.SecondDimSecondEdge,
                AdditionalProcessing = dimension.AdditionalProcessing,
                OrderId = dimension.OrderId,
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                Username = order.Username,
                Material = order.Material
            };
        }
    }

}

