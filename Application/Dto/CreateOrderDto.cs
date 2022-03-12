﻿using AutoMapper;
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
         
        public int ProductId { get; set; }
        public int ClientId { get; set; }

        public int OrderQuantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, Order>();
        }
        
    }
}
