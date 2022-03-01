using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _products;

        public ProductsController(IProductService products)
        {
            _products = products;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //

            return Ok(_products.GetAll());
        }
    }
}
