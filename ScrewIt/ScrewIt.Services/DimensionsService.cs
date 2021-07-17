using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services.DtoModels;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services
{
    public class DimensionsService : IDimensionsService
    {
        private readonly IDimensionsRepository _dimensionsRepository;
        private readonly IOrdersService _ordersService;

        public DimensionsService(
            IDimensionsRepository dimensionsRepository,
            IOrdersService ordersService)
        {
            _dimensionsRepository = dimensionsRepository;
            _ordersService = ordersService;
        }

        public StatusModel CreateDimension(Dimension domainModel)
        {
            var response = new StatusModel();

            var order = _ordersService.GetOrderById(domainModel.OrderId);

            if(order != null)
            {
                var newDimension = new Dimension()
                {
                    FirstDimension = domainModel.FirstDimension,
                    SecondDimension = domainModel.SecondDimension,
                    Quantity = domainModel.Quantity,
                    Rotation = domainModel.Rotation,
                    FirstDimFirstEdge = domainModel.FirstDimFirstEdge,
                    FirstDimSecondEdge = domainModel.FirstDimSecondEdge,
                    SecondDimFirstEdge = domainModel.SecondDimFirstEdge,
                    SecondDimSecondEdge = domainModel.SecondDimSecondEdge,
                    AdditionalProcessing = domainModel.AdditionalProcessing,
                    OrderId = domainModel.OrderId
                };

                _dimensionsRepository.Add(newDimension);
                response.Message = $"The Dimensions with Id: {newDimension.Id} was added to Order with Id: {domainModel.OrderId}";

            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The Order with Id {domainModel.OrderId} was not found";
            }

            return response;
        }
    }
}


