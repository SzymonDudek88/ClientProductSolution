using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cosmonaut;
using Microsoft.Azure.Documents.Client;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using Domain.Entities.Cosmos;

namespace WebApi.Installers
{
    public class CosmosInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var cosmosStoreSettings = new CosmosStoreSettings(
                 configuration["CosmosSettings:DatabaseName"],
                configuration["CosmosSettings:AccountUri"],
                configuration["CosmosSettings:AccountKey"],
              new ConnectionPolicy
              {
                  ConnectionMode = ConnectionMode.Direct,
                  ConnectionProtocol = Protocol.Tcp
              }
              );
            services.AddCosmosStore<CosmosClient> (cosmosStoreSettings);
        }
    }
}
