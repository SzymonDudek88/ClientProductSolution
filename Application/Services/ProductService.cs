using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        // fields
        private readonly IProductRepository _productsRepository;
        private readonly IMapper _mapper;
        //DI ctor

        public ProductService(IProductRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task < IEnumerable<ProductDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var products = await _productsRepository.GetAllAsync( pageNumber,  pageSize); // pobierasz jako typ Product
            return _mapper.Map<IEnumerable<ProductDto>>(products); // zamieniasz na dto i wracasz 
            // i tego jeszcze nie dotyczy automapper config...
        }

        public ProductDto GetById(int id)
        {
            var product = _productsRepository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        //public int GetQuantity(int id)
        //{
        //    var product = _productsRepository.GetById(id);
        //    var mapped = _mapper.Map<ProductDto>(product);
        //    return mapped.Quantity;
        //}

        public ProductDto AddNewProduct(CreateProductDto newProduct)
        {
            // dostajesz newProduct o parametrach Name, Price
            // check if strings are empty
            if (newProduct.Name == null || newProduct.Price == null) // price jest int?
            {
                throw (new Exception("Name or price field can not be empty"));
            }
            // zmapuj new product typu create product dto na product
            var product = _mapper.Map<Product>(newProduct); // to mapowanie nadało mu ID

            // dodaj product do repozytorium
            _productsRepository.Add(product);

            // Zmapuj nowy product na dto
            return _mapper.Map<ProductDto>(product);
            
        }

        public void UpdateProduct(UpdateProductDto updateProduct)// to wchodzi z controllera 
        {
           
            var existingProduct = _productsRepository.GetById(updateProduct.Id); // PRODUCT
            // uwazam ze chce go zmapowac na dto i dodac existing post do _repository add
            var product = _mapper.Map ( updateProduct, existingProduct);  //PRODUCT = updateproductdto -> product
            
            _productsRepository.Update(product);
             // nic nie zwracasz bo tylko update gmoniu
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _productsRepository.GetById(id);
            _productsRepository.Delete(productToDelete);
             
        }

        public void UpdateProductQuantity(int id, int quantity)
        {

            ///
            //var updateQProduct = new UpdateProductQuantityDto();
            //updateQProduct.Quantity = quantity;
            //updateQProduct.Id = id;

            ///
            var existingProduct = _productsRepository.GetById(id); // PRODUCT

            existingProduct.Quantity -= quantity;

           // var product = _mapper.Map(updateQProduct, existingProduct);



            _productsRepository.Update(existingProduct);  // send to repository

        }

        public async Task<int> GetAllClientsAsync()
        {
         return await _productsRepository.GetAllCountAsync();
        }
    }
}
