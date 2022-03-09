﻿using System.Collections.Generic;
using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;  // DTOS
        private readonly IProductService _productService; //DTOS
        private readonly IClientService _clientService; //DTOS

        public OrderController(IOrderService orderService, IProductService productService, IClientService clientService ) // domain -> application - > web api
        {
            _orderService = orderService;
            _clientService = clientService;
            _productService = productService;
        }


        [HttpGet]

        public IActionResult Get()
        {
            var orders = _orderService.GetAll();

            var ordersIds = new List<string>();

            int countOfOrders = 0;
            foreach (var item in orders)
            {
                countOfOrders++;
            }
            string answer = "Ilosc zamowien: " + countOfOrders;
           // return Ok(orders);
            return Ok(answer);

        }
       

        [HttpGet("{idOrder}")]  
        public IActionResult GetById(int idOrder) //  int idC, int idP
        {
            var order = _orderService.GetById(idOrder);

            var client = _clientService.GetById( order.ClientId );
           var product = _productService.GetById( order.ProductId );
           var quantity = order.OrderQuantity; 
           
            

            if (order == null) return NotFound();

               string answer = client.Name.ToString() + " zamówił " + product.Name.ToString() + " w ilości : " + quantity;

              return Ok(answer);
          //  return Ok(order);

        }

        [HttpPost( "{clientId}/{productId}/{quantity}")]
        public IActionResult CreateNewOrder(int clientId, int productId, int quantity)
        {
            var createOrderDto = new CreateOrderDto();
            createOrderDto.ClientId = clientId;
            createOrderDto.ProductId = productId;
            createOrderDto.OrderQuantity = quantity;


            var newOrderDto = _orderService.AddNewOrder(createOrderDto); // adding to repository
            // and getting ID for use
           

            return Created($"api/orders/{newOrderDto.Id}", createOrderDto); // jeszcze przesylasz obiekt!

        }
    }
}
