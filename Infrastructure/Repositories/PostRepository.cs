using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IClientRepository
    {
        private static readonly ISet<Client> _clients = new HashSet<Client>() {

        new Client ( 1, "john", "Vietnam"),
        new Client ( 2, "john2", "Viet3nam"),
        new Client ( 3, "john2", "Viet3nam")
       
        
        
        };
    
        public IEnumerable<Client> GetAll()
        {
            return _clients;
        }

        public Client GetById(int id)
        {
           return _clients.SingleOrDefault(c => c.Id == id);
        }
        public Client Add(Client client)
        {
            client.Id = _clients.Count + 1;
            client.Created = DateTime.UtcNow;
            _clients.Add(client);
            return client;
        }
        public void Update(Client client)
        {
            // poki co nic 
            client.LastModified = DateTime.UtcNow;

        }
        public void Delete(Client client)
        {
            _clients.Remove(client);
        }

    

        

       
    }
}
