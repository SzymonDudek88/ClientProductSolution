using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly ISet<Product> _products = new HashSet<Product>()
        {
         new Product ( 1, "john walker", 100 , 2),
         new Product ( 2, "john bim", 120 , 24),
         new Product ( 3, "jim walker", 110 , 25),
         
        };
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }
        public Product Add(Product product)
        {
            // nadac id
            product.Id = _products.Count() + 1;
            product.Created = DateTime.UtcNow;
            _products.Add(product); 
            return product;
        }
         
        public void Update(Product product)
        {
             // jeszcze nie umiemy update zrobic
             product.LastModified = DateTime.UtcNow;
        }
        public void Delete(Product product)
        {
            _products.Remove(product);
        }
    }
}
