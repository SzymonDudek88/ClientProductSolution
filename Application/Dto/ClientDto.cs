using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ClientDto  // tylko dane ktore chcemy dac do webApi
    {
        public int Id { get; set; }

      //  public string Idc { get; set; }
        public string Name { get; set; }
        public string City  { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, ClientDto>();
        }
    }
}
