using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateOrderDto
    {
        public int Int { get; set; } = 4;
        public Product OrderedProduct { get; set; } // na dto? - nie bo on probuje cos dalej mapowac 
        public Client OrderingClient { get; set; }  // na dto ? 

        //public CreateOrderDto(ProductDto product, ClientDto client)
        //{
        //   OrderedProduct = product;
        //   OrderingClient = client;
        //}
    }
}
