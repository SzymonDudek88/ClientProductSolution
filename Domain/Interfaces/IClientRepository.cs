using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public  interface IClientRepository
    {

        IEnumerable<Client> GetAll();
        Client GetById (int id);

        Client Add(Client client);

        void Update(Client client);
        void Delete(Client client);
        void DeleteAllClients();

    }
}
