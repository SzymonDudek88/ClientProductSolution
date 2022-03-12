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
    public class CreateProductDto : IMap// id bedzie nadane
    {
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, Product>();
        }
    }
}
