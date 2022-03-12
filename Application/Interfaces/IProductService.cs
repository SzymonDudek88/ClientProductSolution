using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
       Task < IEnumerable<ProductDto>> GetAllAsync();

        ProductDto GetById(int id);

        ProductDto AddNewProduct(CreateProductDto newProduct);


        void UpdateProduct(UpdateProductDto updateProduct);
        void DeleteProduct(int id);

        void UpdateProductQuantity(int id, int quantity);
    }
}
