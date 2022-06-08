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
        public OrderDto AddNewOrder(CreateOrderDto createOrderDto, string userId)
        { 
            if (createOrderDto == null) 
            {
                throw (new Exception("Enter values"));
            }
             
            var order = _mapper.Map<Order>(createOrderDto); // error constructor
            order.UserId = userId; // tutaj? 
            
            _orderRepository.Add(order);

            return _mapper.Map<OrderDto>(order);
          
             
        }

        public void DeleteOrder(int id)
        {
            var orderToDelete = _orderRepository.GetById(id);
            _orderRepository.Delete(orderToDelete);
        }

        public bool  UserOwnOrder(int orderId, string userId)
        {
            var order =   _orderRepository.GetById(orderId);

            if (order == null)
            {
                return false;
            }
            if (userId != order.UserId)
            {
                return false;
            }
            return true;
        }

       
    }
}
