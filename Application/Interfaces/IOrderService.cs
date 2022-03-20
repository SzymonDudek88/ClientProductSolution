using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAll();

        OrderDto GetById(int id);

        OrderDto AddNewOrder(CreateOrderDto createOrderDto, string userId); // bo create nie ma id - id se nadamy

      //  void UpdateClient(UpdateOrderDto updateOrder);
        void DeleteOrder(int id);

        bool UserOwnOrder(int orderId, string userId); 

    }
}
