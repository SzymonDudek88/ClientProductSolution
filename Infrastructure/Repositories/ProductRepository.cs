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
        private readonly CPSContext _context;
        public ProductRepository(CPSContext context)
        {
            _context = context;
        }
      
        public async Task< IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Products.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync(); // EFC part
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

        public async Task<int> GetAllCountAsync()
        {
           var count = await  _context.Products.CountAsync();
            return   count;
        }

        //public void UpdateProductQuantity(int id, int quantity)  // no need to use that, quantity is changed in
        // service class via update method
        //{
        //    

        //    
        //}
    }
}
