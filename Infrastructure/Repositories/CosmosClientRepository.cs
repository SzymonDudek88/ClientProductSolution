using Cosmonaut;
using Cosmonaut.Extensions;
using Domain.Entities;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CosmosClientRepository : ICosmosClientRepository
    {
        private readonly ICosmosStore<CosmosClient> _cosmosStore;

        public CosmosClientRepository(ICosmosStore<CosmosClient> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<IEnumerable<CosmosClient>> GetAll()
        {
            var clients = await _cosmosStore.Query().ToListAsync();
            return clients;
        }

        public async Task<CosmosClient> GetById(string id)
        {
           var client = await _cosmosStore.FindAsync(id);
            return client;
        }

        public async Task<CosmosClient> Add(CosmosClient client)
        {
            client.Id = Guid.NewGuid().ToString();
           var newClient =  await _cosmosStore.AddAsync(client); 
            return newClient;
           //  return await _cosmosStore.AddAsync(client) ;  // if problems use this 
        }
        public async Task Update(CosmosClient client)
        {
           await _cosmosStore.UpdateAsync(client); // "z interfejsu"
        }

        public async Task Delete(CosmosClient client)
        {
           await _cosmosStore.RemoveAsync(client);
        }

        public async Task DeleteAllClients()
        {
            await _cosmosStore.RemoveRangeAsync(_cosmosStore.Query().ToList() );  // brdzo ciekaw jstm
        } 
       
    }
}
