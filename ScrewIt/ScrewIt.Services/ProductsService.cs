using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services.DtoModels;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public StatusModel CreateProduct(Product domainModel)
        {
            var response = new StatusModel();

            var newProduct = new Product()
            {
                Name = domainModel.Name,
                Price = domainModel.Price,
                MeasureUnit = domainModel.MeasureUnit,
                ProductType = domainModel.ProductType

            };

            _productsRepository.Add(newProduct);
            response.Message = $"The Product with Id: {newProduct.Id} was added to the Panel List";

            return response;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var product = _productsRepository.GetById(id);

            if (product == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The Product with id {id} was not found";
            }
            else
            {
                _productsRepository.Delete(product);
                response.Message = $"The Product with Name {product.Name} was deleted";
            }

            return response;
        }

        public List<Product> GetAll()
        {
            return _productsRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productsRepository.GetById(id);
        }

        public StatusModel Update(Product domainModel)
        {
            var response = new StatusModel();
            var productForUpdate = _productsRepository.GetById(domainModel.Id);

            if (productForUpdate != null)
            {
                productForUpdate.Name = domainModel.Name;
                productForUpdate.Price = domainModel.Price;
                productForUpdate.MeasureUnit = domainModel.MeasureUnit;
                productForUpdate.ProductType = domainModel.ProductType;

                _productsRepository.Update(productForUpdate);
                response.Message = $"The Product with Name: {productForUpdate.Name} was sucesfully edited ";
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The Product with id {domainModel.Id} was not found";
            }

            return response;
        }
    }
}
