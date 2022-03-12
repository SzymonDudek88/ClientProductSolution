using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection  // serwices of infrastructure layer 
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
         

            //client
            services.AddScoped<IClientRepository, ClientRepository>();// transfered to Infrastructure DI

            // Product
            services.AddScoped<IProductRepository, ProductRepository>();// transfered to Infrastructure DI

            //orders
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
