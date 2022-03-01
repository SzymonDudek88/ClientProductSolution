﻿using Application.Dto;
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

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _productsRepository.GetAll(); // pobierasz jako typ Product
            return _mapper.Map<IEnumerable<ProductDto>>(products); // zamieniasz na dto i wracasz 
            // i tego jeszcze nie dotyczy automapper config...
        }

        public ProductDto GetById(int id)
        {
            var product = _productsRepository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public ProductDto AddNewClient(CreateProductDto newProduct)
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
    }
}
