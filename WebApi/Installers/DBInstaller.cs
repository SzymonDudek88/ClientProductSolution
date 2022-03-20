using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Installers
{
    public class DBInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CPSContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CPOrders"))
            );  // klasa kontekstu 
        }
    }
}
