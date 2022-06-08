using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application //serwisy tej warstwy 
{
    public static class DependencyInjection       
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IClientService, ClientService>(); // transfered to DI in application 
            //client cosmos
         //   services.AddScoped<ICosmosClientService, CosmosClientService>();

            // Product
           services.AddScoped<IProductService, ProductService>();// transfered to DI in application 

            //orders
            services.AddScoped<IOrderService, OrderService>();// transfered to DI in application 

            //DI auto mapper:
            services.AddSingleton(AutoMapperConfig.Initialize()); // to tez jest DI
          //  services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;

        }


    }
}
