using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Installers
{
    public interface IInstaller //L7
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
           
        }
    }
}
