using AutoMapper;
using Domain.Entities.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Cosmos
{
    public class CosmosClientDto
    {
        public string Id { get; set; }

        //  public string Idc { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CosmosClient, CosmosClientDto>();
        }
    }
}
