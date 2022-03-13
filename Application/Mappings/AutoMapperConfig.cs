using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.Cosmos;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Cosmos;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        // minusy rozwiazania mapowania po staremu : za każdym razem kiedy dodajemy nowy obiekt dto
        // i chcemy mapowac to trzeba pamietac aby tu dodac mapowanie
        // z poziomu dto nie widac jak sie mapują
        // przenosimy mapowanie bezposrednio do dto
        public static IMapper Initialize() 
            => new MapperConfiguration
            (
             cfg =>
            {
                cfg.CreateMap<Client, ClientDto>(); // z lewej na prawo -->
                cfg.CreateMap<ClientDto, Client>(); // z lewej na prawo -->
                cfg.CreateMap<CreateClientDto, Client>(); // w ClientService - rzutujesz na klienta z nowego createclientdto - zeby go dodac
                                                          // do zbioru CLIENTów
                cfg.CreateMap<CosmosClient, CosmosClientDto>(); // z lewej na prawo -->
                cfg.CreateMap<CosmosClientDto, CosmosClient>(); // z lewej na prawo -->
                cfg.CreateMap<CreateCosmosClientDto, CosmosClient>();
                cfg.CreateMap<UpdateCosmosClientDto, CosmosClient>();


                //for products:
                cfg.CreateMap<Product, ProductDto>(); // mapuje sie z lewej do prawej -->
                 cfg.CreateMap<ProductDto, Product>(); // mapuje sie z lewej do prawej -->
                 cfg.CreateMap< CreateProductDto, Product>(); // to dopiero do create potrzebne
                                                              // potestuj jak bedziesz mial controller
                
                //for orders:
                cfg.CreateMap<Order, OrderDto>();
                cfg.CreateMap<CreateOrderDto, Order>();

                cfg.CreateMap<UpdateProductDto, Product>();
                cfg.CreateMap<UpdateClientDto, Client>();
            }
            ) .CreateMapper();
        

    }
}
