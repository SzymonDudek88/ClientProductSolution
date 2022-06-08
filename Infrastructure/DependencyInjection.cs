using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection  // services of infrastructure layer 
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
         

            //client
           services.AddScoped<IClientRepository, ClientRepository>();// transfered to Infrastructure DI
            //cosmos client
         //   services.AddScoped<ICosmosClientRepository, CosmosClientRepository>();

            // Product
            services.AddScoped<IProductRepository, ProductRepository>();// transfered to Infrastructure DI

            //orders
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
