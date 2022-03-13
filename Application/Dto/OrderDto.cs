using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ClientId { get; set; } // zmieniono

        public int OrderQuantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>();
        }
    }
}
