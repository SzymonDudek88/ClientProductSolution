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
         new Order ( 1, new Product(4, "NowyJohn1", 12, 10) ,   new Client(4, "Sklep A" , "Siemianowice" )),
         new Order ( 2, new Product(4, "NowyJohn2", 12, 12) ,   new Client(5, "Sklep B" , "Siemianowice" )),
         new Order ( 3, new Product(4, "JNowyJohn3", 12, 13) ,   new Client(6, "Sklep C" , "Siemianowice" )),
          
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
