using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CPSContext _context;
        public ClientRepository(CPSContext context)
        {
            _context = context;
        }
        //private static readonly ISet<Client> _clients = new HashSet<Client>() { 
        //new Client ( 1, "john", "Vietnam"),
        //new Client ( 2, "john2", "Viet3nam"),
        //new Client ( 3, "john2", "Viet3nam") 
        //};

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients;
        }

        public Client GetById(int id)
        {
            return _context.Clients.SingleOrDefault(c => c.Id == id);
        }
        public Client Add(Client client)
        {
            client.Created = DateTime.UtcNow;
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client;
        }
        public void Update(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();


        }
        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public void DeleteAllClients()
        {
            foreach (var client in _context.Clients)
            {
                _context.Clients.Remove(client);

            }
            _context.SaveChanges();

        }
    }
}
