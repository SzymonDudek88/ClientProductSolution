using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using WebApi.Wrappers;

namespace WebApi.Controllers.V1
{ //added nuget package mvc versioning L9 S3

    // [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;  // DTOS
        private readonly IProductService _productService; //DTOS
        private readonly ICosmosClientService _clientService; //DTOS

        public OrderController(IOrderService orderService, IProductService productService, ICosmosClientService clientService ) // domain -> application - > web api
        {
            _orderService = orderService;
            _clientService = clientService;
            _productService = productService;
        }

        [AllowAnonymous]
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
            return Ok(orders);
           // return Ok(answer);

        }

       //  [AllowAnonymous]
        [HttpGet("{idOrder}")]  
        public IActionResult GetById(int idOrder) //  int idC, int idP
        {
            var order = _orderService.GetById(idOrder);

            var client = _clientService.GetByIdAsync( order.ClientId.ToString() );
           var product = _productService.GetById( order.ProductId );
           var quantity = order.OrderQuantity;

            if (product == null || client == null || order == null)
            {
                return NotFound("Make sure you entered correct data ");
            }

            if (order == null) return NotFound();

               string answer = client.Result.Name  + " zamówił " + product.Name.ToString() + " w ilości : " + quantity;

              return Ok(answer);
          //  return Ok(order);

        }

       //  [AllowAnonymous] 
        [HttpPost("{clientId}/{productId}/{quantity}")]
        public IActionResult CreateNewOrder(string clientId, int productId, int quantity)
        {
            var createOrderDto = new CreateOrderDto();
            createOrderDto.ClientId = clientId;
            createOrderDto.ProductId = productId;
            createOrderDto.OrderQuantity = quantity;

            var client = _clientService.GetByIdAsync(clientId.ToString());
            var product = _productService.GetById(productId);

            // check if client prouct exist
            if (client == null && product == null) return NotFound("Client and product do not exist");
            if (client == null ) return NotFound("Client does not exist ");
            if ( product == null) return NotFound("Product does not exist ");

            // check if quantity of existing product is enaught to cover the order 
            //the quantity of the order cannot be covered by magazine suplies

            if (quantity > product.Quantity) return BadRequest("The quantity of the order cannot be covered by magazine suplies");

            //if possible - change quantity of product
             _productService.UpdateProductQuantity(product.Id, quantity);

            // get product again  - with new quantity
            product = _productService.GetById(productId);

            var userNameString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newOrderDto = _orderService.AddNewOrder(createOrderDto, userNameString);  // security claims // adding to repository
            // and getting ID for use
           

            return Created($"api/orders/{newOrderDto.Id} ", $"Client: {client.Result.Name} Ordered: {product.Name} Amount: {newOrderDto.OrderQuantity}  Product amount left: {product.Quantity}"); 

        }
        [HttpDelete]

        public   IActionResult DeleteOrder(int id)
        {
            var isOwner = _orderService.UserOwnOrder(id, User.FindFirstValue(ClaimTypes.NameIdentifier)); // to wartosc id string
            // przypisana danemu uzytkownikowi na poziomie rejestracji
            if (!isOwner)
            {
                return BadRequest(new Response<bool>() { Success = false, Message = "You Dont own this order so cant delete it" });
            }
            _orderService.DeleteOrder(id);
            return NoContent();
        
        }
    }
}
