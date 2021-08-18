using ScrewIt.Models;
using ScrewIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScrewIt.Repositories
{
    public class ProductsRepository : BaseRepository<Product>, IProductsRepository
    {
        public ProductsRepository(ScrewItDbContext context) : base(context)
        {
        }

        public Product CheckIfExist(string product)
        {
            return _context.Products.FirstOrDefault(x => x.Name.ToLower() == product.ToLower());
        }
    }
}
