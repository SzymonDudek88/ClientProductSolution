﻿using Application.Dto;
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Security.Claims;
using WebApi.Wrappers;

namespace WebApi.Controllers.V1
{  

    // [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
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

        [SwaggerOperation(Summary = "Get all Orders")]
         [AllowAnonymous]
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpGet("[action]")]
       
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
            return Ok(orders);
           // return Ok(answer);

        }

      [AllowAnonymous] 
        [SwaggerOperation(Summary = "Get Order by id")]
       // [Authorize(Roles = UserRoles.User)] 
        [HttpGet("{idOrder}")]  
        public IActionResult GetById(int idOrder) //   
        {
            var order = _orderService.GetById(idOrder);
            // check if order is not null

        if (order == null)
                return NotFound();

            var client = _clientService.GetById( order.ClientId );
           var product = _productService.GetById( order.ProductId );
           var quantity = order.OrderQuantity;

            if (product == null || client == null || order == null)
            {
                return NotFound("Make sure you entered correct data ");
            }

            if (order == null) return NotFound();

               string answer = client.Name  + " zamówił " + product.Name.ToString() + " w ilości : " + quantity;

              return Ok(answer);
          //  return Ok(order);

        }


       [AllowAnonymous] 
        [SwaggerOperation(Summary = "Create new Order")]
        //[Authorize(Roles = UserRoles.User)]
        [HttpPost("{clientId}/{productId}/{quantity}")]
        public IActionResult CreateNewOrder(int clientId, int productId, int quantity)
        {
            if (( string.IsNullOrWhiteSpace(clientId.ToString())) || (string.IsNullOrWhiteSpace(productId.ToString())) || (string.IsNullOrWhiteSpace(quantity.ToString())))
                return BadRequest(new Response<bool>() { Success = false, Message = "Retrieved empty field" });


            var client = _clientService.GetById(clientId );
            var product = _productService.GetById(productId);

            // check if client prouct exist
            if (client   == null && product == null) return NotFound("Client and product do not exist");
            if (client  == null ) return NotFound("Client does not exist ");
            if ( product == null) return NotFound("Product does not exist ");

            // check if quantity of existing product is enaught to cover the order 
            //the quantity of the order cannot be covered by magazine suplies

            if (quantity > product.Quantity) return BadRequest("The quantity of the order cannot be covered by magazine suplies");

            var createOrderDto = new CreateOrderDto(productId, clientId, quantity);
           
            //if possible - change quantity of product
            _productService.UpdateProductQuantity(product.Id, quantity);

            // get product again  - with new quantity
            product = _productService.GetById(productId);

            // sprawdza zalogowanego uzytkownika i jego string id
            var userNameString = User.FindFirstValue(ClaimTypes.NameIdentifier); // sprawdza nazwe obecnego usera
           
            var newOrderDto = _orderService.AddNewOrder(createOrderDto,   userNameString );  // security claims // adding to repository
            // and getting ID for use
           

            return Created($"api/orders/{newOrderDto.Id} ", $"Client: {client.Name} Ordered: {product.Name} Amount: {newOrderDto.OrderQuantity}  Product amount left: {product.Quantity}"); 

        }

        [AllowAnonymous] 
        [SwaggerOperation(Summary = "Delete Order by id")]
        [HttpDelete]
      //  [Authorize(Roles = UserRoles.AdminOrUser)]
        
        public IActionResult DeleteOrder(int id)
        {                                           //  comparing 
            var isOwner = _orderService.UserOwnOrder(id,  User.FindFirstValue(ClaimTypes.NameIdentifier)); // to wartosc id string
            // przypisana danemu uzytkownikowi na poziomie rejestracji
            var isAdmin = User.FindFirstValue(ClaimTypes.Role).Contains(UserRoles.Admin);
            
            if (!isAdmin && !isOwner)
            {
                return BadRequest(new Response<bool>() { Success = false, Message = "You Dont own this order so cant delete it" });
            }
            _orderService.DeleteOrder(id);
            return NoContent();
        
        }
    }
}
