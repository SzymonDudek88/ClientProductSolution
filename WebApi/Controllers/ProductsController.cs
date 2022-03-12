using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;

        public ProductsController(IProductService products)
        {
            _productsService = products;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllAsync()
        {
            //
            var products = await _productsService.GetAllAsync(); 
            return Ok(products);
        }
     

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            // check if exist?
            var product = _productsService.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        //[HttpGet("Id")]
        //public IActionResult GetQuantityById(int id)
        //{
        //    var product = _productsService.GetById(id);
        //     var quantity = _productsService.GetQuantity(id);

        //    return Ok(product);
        //}

        [HttpPost]
        public IActionResult CreateNewProduct(CreateProductDto newProduct)
        { 

         var product =  _productsService.AddNewProduct(newProduct); // bo dopiero teraz on dostał id
       
           // return Ok(product);

            return Created($"api/posts/{product.Id}", newProduct); // widac nie chcesz pokazac jego id bo w sumie po co to po masz dto

        }

        [HttpPut]
        public IActionResult Update(UpdateProductDto updateProduct)
        { 
        _productsService.UpdateProduct(updateProduct);
         return NoContent();
        
        }
      

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var product =  _productsService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productsService.DeleteProduct(id);
            return NoContent();
        }

        [HttpPut("{id}/{quantity}")]//"{id}/{quantity}"
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            //var updateQproduct = new UpdateProductQuantityDto();
            //updateQproduct.Quantity = quantity;
            //updateQproduct.Id = id;

            _productsService.UpdateProductQuantity(id, quantity);
            return NoContent( ); 

        }
        //SwaggerGeneratorException: Conflicting method/path combination "PUT api/Products" for actions
        //- WebApi.Controllers.ProductsController.Update (WebApi),WebApi.Controllers.ProductsController.UpdateQuantity
        //(WebApi).
        //Actions require a unique method/path combination for Swagger/OpenAPI 3.0.
        //Use ConflictingActionsResolver as a workaround
    }
}
