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
        CosmosClient GetById(int id);

        Client Add(CosmosClient client);

        void Update(CosmosClient client);
        void Delete(CosmosClient client);
        void DeleteAllClients();
    }
}
