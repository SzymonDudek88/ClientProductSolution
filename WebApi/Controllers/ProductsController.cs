using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;
using WebApi.Helpers;
using WebApi.Wrappers;

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

        [HttpGet]  //                               from querry - zostanie pobrana z ciagu zapytania 
        public async Task <IActionResult> GetAllAsync([FromQuery]PaginationFilter filter) //pagination filter - tylko filtruje dane
        {
            var validPaginationFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //
            var products = await _productsService.GetAllAsync( validPaginationFilter.PageNumber, validPaginationFilter.PageSize);
            var totalRecords = await _productsService.GetAllClientsAsync();
            
            return Ok(  PaginationHelper.CreatePagedResponse(products, validPaginationFilter,totalRecords)); //pagination int pageNumber, int pageSize
        }
     

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            // check if exist?
            var product = _productsService.GetById(id);
            if (product == null) return NotFound();
            return Ok(new Response<ProductDto> (product));
        }
         

        [HttpPost]
        public IActionResult CreateNewProduct(CreateProductDto newProduct)
        { 

         var product =  _productsService.AddNewProduct(newProduct); 
       
           // return Ok(product);

            return Created($"api/posts/{product.Id}", new Response<ProductDto>( product));  

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
             

            _productsService.UpdateProductQuantity(id, quantity);
            return NoContent( ); 

        }
        
    }
}
