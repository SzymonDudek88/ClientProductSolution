﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() 
            => new MapperConfiguration
            (
             cfg =>
            {
                cfg.CreateMap<Client, ClientDto>();
            

            }
            ) .CreateMapper();
        

    }
}
