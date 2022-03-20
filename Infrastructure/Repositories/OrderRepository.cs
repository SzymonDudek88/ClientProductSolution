using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CPSContext _context;
        public OrderRepository(CPSContext context)
        {
            _context = context;
        }

        //private static readonly ISet<Order> _orders = new HashSet<Order>()
        //{
        // new Order ( 1, 2 , 2, 22),
        // new Order ( 2, 1 , 1, 122),
        // new Order ( 3, 3 , 4, 322) 
        //};

        public IEnumerable<Order> GetAll()
        {
           return _context.Orders;
        }
        public Order GetById(int id)
        {
           return _context.Orders.SingleOrDefault(o => o.Id == id);
        }
        public Order Add(Order order) // mnot sure
        {
           //  order.ProductId = order.ProductId;
            order.Created = DateTime.UtcNow;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void Delete(Order order)
        {
           _context.Orders.Remove(order);
            _context.SaveChanges();
        }

      
        // _context.Orders.Update(order); save changes ()
      
    }
}
