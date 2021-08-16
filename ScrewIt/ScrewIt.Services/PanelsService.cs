using ScrewIt.Models;
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
                    Price = domainModel.Price,
                    MeasureUnit = MeasureUnit.Panel
                    
            };

                _panelsRepository.Add(newPanel);
                response.Message = $"The Panel with Id: {newPanel.Id} was added to the Panel List";

            return response;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var panel = _panelsRepository.GetById(id);

            if (panel == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The Panel with id {id} was not found";
            }
            else
            {
                _panelsRepository.Delete(panel);
                response.Message = $"The Panel with Name {panel.Name} was deleted";
            }

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

        public StatusModel Update(Panel domainModel)
        {
            var response = new StatusModel();
            var panelForUpdate = _panelsRepository.GetById(domainModel.Id);

            if(panelForUpdate != null)
            {
                panelForUpdate.Name = domainModel.Name;
                panelForUpdate.Thickness = domainModel.Thickness;
                panelForUpdate.Length = domainModel.Length;
                panelForUpdate.Height = domainModel.Height;
                panelForUpdate.Price = domainModel.Price;

                _panelsRepository.Update(panelForUpdate);
                response.Message = $"The Panel with Name: {panelForUpdate.Name} was sucesfully edited ";
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The Panel with id {domainModel.Id} was not found";
            }

            return response;
        }

    }

}
