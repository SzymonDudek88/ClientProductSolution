using Domain.Entities;
using Domain.Entities.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICosmosClientRepository
    {
       Task< IEnumerable<CosmosClient>> GetAll();
       Task <CosmosClient> GetById(string id);

        Task <CosmosClient> Add(CosmosClient client);

        Task Update(CosmosClient client);
        Task Delete(CosmosClient client);
        Task DeleteAllClients();
    }
}
