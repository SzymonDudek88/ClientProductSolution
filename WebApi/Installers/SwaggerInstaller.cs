using Microsoft.AspNetCore.Authentication.JwtBearer;
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

                // gotowy kod z dokumentacji swagger - schemat uwierzytelniania - tworzy przycisk do wpisania  authorize za pomoca tokena 
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

            });
            // -------

        }



    }

}
