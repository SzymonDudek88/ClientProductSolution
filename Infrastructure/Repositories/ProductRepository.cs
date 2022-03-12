using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrdersContext _context;
        public ProductRepository(OrdersContext context)
        {
            _context = context;
        }
        //private static readonly ISet<Product> _products = new HashSet<Product>()
        //{
        // new Product ( 1, "john walker", 100 , 2),
        // new Product ( 2, "john bim", 120 , 24),
        // new Product ( 3, "jim walker", 110 , 25), 
        //};
        public async Task< IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); // EFC part
        }

        public Product GetById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }
        public Product Add(Product product)
        {
            product.Created = DateTime.UtcNow;
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
         
        public void Update(Product product)  // id is theproblem cannot use id to update this entity
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        //public void UpdateProductQuantity(int id, int quantity)  // no need to use that, quantity is changed in
        // service class via update method
        //{
        //    

        //    
        //}
    }
}
