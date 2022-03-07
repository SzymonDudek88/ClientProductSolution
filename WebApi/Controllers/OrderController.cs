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
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) // domain -> application - > web api
        {
            _orderService = orderService;
        }
        [SwaggerOperation(Summary = "Retrivies all orders")] //schwackbuckle annotations -> w startup adnotacje wlacz !
        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);

        }

        [HttpGet("{id}")] 
        public IActionResult GetById(int id)
        {
            var order = _orderService.GetById(id);
            if (order == null) return NotFound();
            return Ok(order);

        }

        [HttpPost] 
        public IActionResult CreateNewClient(CreateOrderDto newOrder)
        {
            var order = _orderService.AddNewOrder(newOrder);

            return Created($"api/posts/{order.Id}", newOrder); // jeszcze przesylasz obiekt!

        }
    }
}
