using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        // DI 
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public IEnumerable<ClientDto> GetAll()
        {
            var posts = _clientRepository.GetAll();
            return from p in posts
                   select new ClientDto { Id = p.Id, Name = p.Name, City = p.City };
        }

        public ClientDto GetById(int id)
        {
             var post = _clientRepository.GetById(id);
            return new ClientDto {
                Id = post.Id,
                Name = post.Name,
                City = post.City

            };
            
        }
    }
}
