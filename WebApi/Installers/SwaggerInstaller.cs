using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebApi.Installers
{
    public class SwaggerInstaller : IInstaller // L7 as mvc and Iinstaller 
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations(); // adnotacje swagger
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
        }
    }
}
