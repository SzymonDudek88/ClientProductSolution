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
        public OrderDto AddNewOrder(CreateOrderDto newOrder)
        {
            if (newOrder.OrderedProduct == null || newOrder.OrderingClient == null) // price jest int?
            {
                throw (new Exception("Client or product cannot be empty"));
            }
            var order = _mapper.Map<Order>(newOrder); //get id

            _orderRepository.Add(order);

            return _mapper.Map<OrderDto>(order);
            //// dostajesz newProduct o parametrach Name, Price
            //// check if strings are empty
            //if (newProduct.Name == null || newProduct.Price == null) // price jest int?
            //{
            //    throw (new Exception("Name or price field can not be empty"));
            //}
            //// zmapuj new product typu create product dto na product
            //var product = _mapper.Map<Product>(newProduct); // to mapowanie nadało mu ID

            //// dodaj product do repozytorium
            //_productsRepository.Add(product);

            //// Zmapuj nowy product na dto
            //return _mapper.Map<ProductDto>(product);
        }

        public void DeleteOrder(int id)
        {
            var orderToDelete = _orderRepository.GetById(id);
            _orderRepository.Delete(orderToDelete);
        }

     
    }
}
