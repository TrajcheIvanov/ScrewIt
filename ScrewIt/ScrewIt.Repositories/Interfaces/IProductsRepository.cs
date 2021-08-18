using ScrewIt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrewIt.Repositories.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Product>
    {
        Product CheckIfExist(string product);
    }
}
