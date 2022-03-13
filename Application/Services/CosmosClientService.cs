using Application.Dto.Cosmos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CosmosClientService : ICosmosClientService
    {
        private readonly ICosmosClientRepository _clientRepository;
        private readonly IMapper _mapper;
        // DI 
        public CosmosClientService(ICosmosClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CosmosClientDto>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAll();
            return _mapper.Map<IEnumerable<CosmosClientDto>>(clients);
        }

        public async Task<CosmosClientDto> GetByIdAsync(string id)
        {
            var client = await _clientRepository.GetById(id);
            return _mapper.Map<CosmosClientDto>(client);
        }

        public async Task UpdateClientAsync(UpdateCosmosClientDto updateClient)
        {
            var existingClient = await _clientRepository.GetById(updateClient.Id);

            var client = _mapper.Map(updateClient, existingClient); // maping musi byc skonfigurowany wczesniej w config AM

            await _clientRepository.Update(client);
        }
        public async Task<CosmosClientDto> AddNewClientAsync(CreateCosmosClientDto newClient)
        {
            if (string.IsNullOrEmpty(newClient.Name))
            {
                throw new Exception("Client can not have empty name");
            }
            
            var client =   _mapper.Map<CosmosClient>(newClient);

           await _clientRepository.Add(client);
           
            return _mapper.Map<CosmosClientDto>(client); // jakbys dal new client to on nie ma nadanego id a przerobienie go na client typu client
            
        }

        public async Task DeleteAllClientsAsync()
        {
           await _clientRepository.DeleteAllClients();
        }

        public async Task DeleteClientAsync(string id)
        {
            var clientToDelete = await _clientRepository.GetById(id);

         await   _clientRepository.Delete(clientToDelete);
        }

       
    }
}
