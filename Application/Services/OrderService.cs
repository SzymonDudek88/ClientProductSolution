using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;


        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;    
            _mapper = mapper;   

        }
        public IEnumerable<OrderDto> GetAll()
        {
            var orders = _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public OrderDto GetById(int id)
        {
            var order = _orderRepository.GetById(id);
            return _mapper.Map<OrderDto>(order);
        }
        public OrderDto AddNewOrder( ProductDto product, ClientDto client)
        { //maybe i should not transfer objects but only IDs
            if (product == null || client == null) // price jest int?
            {
                throw (new Exception("Client or product cannot be empty"));
            }

            var productMapped = _mapper.Map<Product>(product);
            var clientMapped = _mapper.Map<Client>(client);

         // /  [External Code]
         //   Application.Services.OrderService.AddNewOrder(Application.Dto.ProductDto, Application.Dto.ClientDto) in OrderService.cs
  //  WebApi.Controllers.OrderController.CreateNewOrder(int, int) in OrderController.cs
  ///  [External Code]
            var newOrder = new CreateOrderDto( );
            newOrder.OrderedProduct = productMapped;
            newOrder.OrderingClient = clientMapped;

            var order = new Order(4, productMapped, clientMapped);

            // you simply have to solve this here, because you dont have connections to other dastabases deeper
          //  var order = _mapper.Map<Order>(newOrder); //get id
            // just trying to transfer wrong type DTOsObjects not directObjects
            _orderRepository.Add(order);

            return _mapper.Map<OrderDto>(order); // gives id  to otderDto
             
        }

        public void DeleteOrder(int id)
        {
            var orderToDelete = _orderRepository.GetById(id);
            _orderRepository.Delete(orderToDelete);
        }

     
    }
}
