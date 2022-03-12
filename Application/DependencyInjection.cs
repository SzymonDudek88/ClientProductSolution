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
    public static class DependencyInjection      //L7Section3 // created to simplyfiy and order structure of api
    {
        //added nuget package  DI abstrsctions
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // L8 S3 + biblioteka automapper extension microsoft dependency injection 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //TRANSFERED FROM WEB API layer

            //client
            services.AddScoped<IClientService, ClientService>(); // transfered to DI in application 

            // Product
           services.AddScoped<IProductService, ProductService>();// transfered to DI in application 

            //orders
            services.AddScoped<IOrderService, OrderService>();// transfered to DI in application 

            //DI auto mapper:
            services.AddSingleton(AutoMapperConfig.Initialize()); // to tez jest DI

            return services;

        }


    }
}
