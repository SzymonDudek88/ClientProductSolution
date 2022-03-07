using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Order GetById(int id);

        Order Add(Order order); // bo create nie ma id - id se nadamy

        //  void UpdateClient(UpdateOrderDto updateOrder);
        void Delete(Order order);
    }
}
