using ScrewIt.Models;
using ScrewIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt.Mappings
{
    public static class ViewModelExtensions
    {
        public static Order ToOrderModel(this OrderCreateModel order)
        {
            return new Order()
            {
                Username = order.Username,
                Material = order.Material,
                PanelId = order.PanelId
            };
        }

        public static Dimension ToDimensionModel(this DimensionCreateRequestModel dimension)
        {
            return new Dimension()
            {
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

        public static Panel ToPanelModel(this PanelCreateModel panel)
        {
            return new Panel()
            {
                Name = panel.Name,
                Thickness = panel.Thickness,
                Length = panel.Length,
                Height = panel.Height,
                Price = panel.Price
            };
        }

        public static Panel ToModel(this PanelViewModel panel)
        {
            return new Panel()
            {
                Id = panel.Id,
                Name = panel.Name,
                Thickness = panel.Thickness,
                Length = panel.Length,
                Height = panel.Height,
                Price = panel.Price
            };
        }
    }
}
