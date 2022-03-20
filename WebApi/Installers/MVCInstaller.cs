using Application;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Installers
{
    public class MVCInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration) //L7
        {

            // everything transfered here L7 - Dependency injection and services registration
            //Dependency Injection klas obłsugiwanych: Client
          // services.AddScoped<IClientRepository, ClientRepository>();// transfered to Infrastructure DI
           //  services.AddScoped<IClientService, ClientService>(); // transfered to DI in application 

            // Product
            //   services.AddScoped<IProductRepository, ProductRepository>();// transfered to Infrastructure DI
            // services.AddScoped<IProductService, ProductService>();// transfered to DI in application 

            //orders
            //  services.AddScoped<IOrderRepository, OrderRepository>(); // transfered to Infrastructure DI
            // services.AddScoped<IOrderService, OrderService>();// transfered to DI in application 

            //DI auto mapper:
            //  services.AddSingleton(AutoMapperConfig.Initialize()); // transfered to Application DI

            services.AddApplication();
            services.AddInfrastructure();
           // services.AddControllers(); // to bylo przed cosmos

            services.AddControllers().AddNewtonsoftJson(options =>  // to niezbedo do cosmos
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // versioning
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;


            });

            services.AddAuthentication(); // tu i w startup
        }
    }
}
