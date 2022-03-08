using System.Collections.Generic;
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


            return Ok(orders);

        }

        [HttpGet("{idOrder}")] //  ("{idOrder}/{idClient}/{idProduct}")
        public IActionResult GetById(int idOrder) //  int idC, int idP
        {
            var order = _orderService.GetById(idOrder);

            var client = order.OrderingClient;
           var product = order.OrderedProduct; 
           
            

            if (order == null) return NotFound();

               string answer = client.Name.ToString() + " zamówił " + product.Name.ToString() + " w ilości : " + product.Quantity.ToString();

            //  return Ok(answer);
            return Ok(order);

        }

        [HttpPost]
        public IActionResult CreateNewOrder(CreateOrderDto newOrder)
        {
            var order = _orderService.AddNewOrder(newOrder);

            return Created($"api/orders/{order.Id}", newOrder); // jeszcze przesylasz obiekt!

        }
    }
}
