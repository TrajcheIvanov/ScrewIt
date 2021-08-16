using ScrewIt.Models;
using ScrewIt.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Services.Interfaces
{
    public interface IProductsService
    {
        List<Product> GetAll();
        StatusModel CreateProduct(Product domainModel);
        Product GetById(int id);
        StatusModel Update(Product domainModel);
        StatusModel Delete(int id);
    }
}
