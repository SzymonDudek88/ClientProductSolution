using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public  class UpdateProductQuantityDto : IMap
    {
        public int Id { get; set; }
 
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
           profile.CreateMap<CreateProductDto, Product>();
        }
    }
}
