using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services.DtoModels;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services
{
    public class ReceiptsService : IReceiptsService
    {

        private readonly IReceiptsRepository _receiptsRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IPanelsRepository _panelsRepository;

        public ReceiptsService(
            IReceiptsRepository receiptsRepository,
            IProductsRepository productsRepository,
            IPanelsRepository panelsRepository)
        {
            _receiptsRepository = receiptsRepository;
            _productsRepository = productsRepository;
            _panelsRepository = panelsRepository;
        }

        public CheckProductResponse CheckIfProductIsValid(string product)
        {
            var response = new CheckProductResponse();


            var panelResponse = _panelsRepository.CheckIfExist(product);

            if(panelResponse == null)
            {
                var productResponse = _productsRepository.CheckIfExist(product);

                if(productResponse == null)
                {
                    response.Status.IsSuccessful = false;
                }
                else
                {
                    response.ProductId = productResponse.Id;
                    response.Type = "product";
                }
            }
            else
            {
                response.ProductId = panelResponse.Id;
                response.Type = "panel";
            }

            return response;
        }

        public List<string> GetProductOffer(string term)
        {
            var stringToReturn = new List<String>();


            var panels = _panelsRepository.GetAll();

            foreach (var panel in panels)
            {
                if (panel.Name.ToLower().Contains(term.ToLower()))
                {
                    stringToReturn.Add(panel.Name);
                }
            }

            var products = _productsRepository.GetAll();

            foreach (var product in products)
            {
                if (product.Name.ToLower().Contains(term.ToLower()))
                {
                    stringToReturn.Add(product.Name);
                }
            }

            return stringToReturn;
        }
    } 
}
