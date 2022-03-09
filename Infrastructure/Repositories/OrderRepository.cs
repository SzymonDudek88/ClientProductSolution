using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private static readonly ISet<Order> _orders = new HashSet<Order>()
        {
         new Order ( 1, 2 , 2, 22),
         new Order ( 2, 1 , 1, 122),
         new Order ( 3, 3 , 4, 322)
       
          
        };

        public IEnumerable<Order> GetAll()
        {
           return _orders;
        }
        public Order GetById(int id)
        {
           return _orders.FirstOrDefault(o => o.Id == id);
        }
        public Order Add(Order order)
        {
            order.Id = _orders.Count + 1;
            order.Created = DateTime.UtcNow;
            _orders.Add(order);
            return order;
        }

        public void Delete(Order order)
        {
            _orders.Remove(order);
        }

      

      
    }
}
