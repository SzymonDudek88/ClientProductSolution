using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Installers
{
    public interface IInstaller //L7
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration); //L7
    }
}
