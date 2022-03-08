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

            int countOfOrders = 0;
            foreach (var item in orders)
            {
                countOfOrders++;
            }
            string answer = "Ilosc zamowien: " + countOfOrders;
           // return Ok(orders);
            return Ok(answer);

        }
       

        [HttpGet("{idOrder}")] //  ("{idOrder}/{idClient}/{idProduct}")
        public IActionResult GetById(int idOrder) //  int idC, int idP
        {
            var order = _orderService.GetById(idOrder);

            var client = order.OrderingClient;
           var product = order.OrderedProduct; 
           
            

            if (order == null) return NotFound();

               string answer = client.Name.ToString() + " zamówił " + product.Name.ToString() + " w ilości : " + product.Quantity.ToString();

              return Ok(answer);
          //  return Ok(order);

        }

        [HttpPost( "{idClient}/{idProduct}")]
        public IActionResult CreateNewOrder(int idClient, int idProduct)
        {
            //maybe i just want to get clientdto and product dto and then
            // send it to orderService - there i get back order as OrderDto
            // to use its ID
            // 
            var client = _clientService.GetById(idClient);
            var product = _productService.GetById(idProduct);
            // sent them to orderService

            var newOrderDto = _orderService.AddNewOrder(product, client ); // adding to repository
            // and getting ID for use
           

            return Created($"api/orders/{newOrderDto.Id}", newOrderDto); // jeszcze przesylasz obiekt!

        }
    }
}
