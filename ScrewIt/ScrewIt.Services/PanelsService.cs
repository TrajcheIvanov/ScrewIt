﻿using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services.DtoModels;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services
{
    public class PanelsService : IPanelsService
    {
        private readonly IPanelsRepository _panelsRepository;

        public PanelsService(IPanelsRepository panelsRepository)
        {
            _panelsRepository = panelsRepository;
        }

        public StatusModel CreatePanel(Panel domainModel)
        {
            var response = new StatusModel();

            var newPanel = new Panel ()
                {
                    Name = domainModel.Name,
                    Thickness = domainModel.Thickness,
                    Length = domainModel.Length,
                    Height = domainModel.Height,
                    Price = domainModel.Price
            };

                _panelsRepository.Add(newPanel);
                response.Message = $"The Panel with Id: {newPanel.Id} was added to the Panel List";

            return response;
        }

        public List<Panel> GetAll()
        {
            return _panelsRepository.GetAll();
        }

        public Panel GetById(int id)
        {
            return _panelsRepository.GetById(id);
        }
    }

}
