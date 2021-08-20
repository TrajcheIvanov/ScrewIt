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
                Username = order.User.Name,
                OrderDescription = order.OrderDescription,
                PanelName = order.Panel.Name + " - " + order.Panel.Length + "x" + order.Panel.Height + "x" + order.Panel.Thickness + " mm"
            };
        }

        public static UserViewModel ToViewModel(this ApplicationUser user, string roleName)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                RoleName = roleName,
                PhoneNumber = user.PhoneNumber
            };
        }

        public static PanelViewModel ToViewModel(this Panel panel)
        {
            return new PanelViewModel()
            {
                Id = panel.Id,
                Name = panel.Name,
                Thickness = panel.Thickness,
                Length = panel.Length,
                Height = panel.Height,
                Price = panel.Price


            };
        }

        public static ProductViewModel ToViewModel(this Product panel)
        {
            return new ProductViewModel()
            {
                Id = panel.Id,
                Name = panel.Name,
                Price = panel.Price,
                MeasureUnit = panel.MeasureUnit,
                ProductType = panel.ProductType
            };
        }
    }

}

