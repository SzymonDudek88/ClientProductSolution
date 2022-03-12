using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class ClientService : IClientService // obsługa repozytorium pod katem dto
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        // DI 
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

   

        public IEnumerable<ClientDto> GetAll()
        {
            var clients = _clientRepository.GetAll();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public ClientDto GetById(int id)
        {
             var client = _clientRepository.GetById(id);
            return  _mapper.Map<ClientDto>(client);
            
            
        }
        public ClientDto AddNewClient(CreateClientDto newClient)
        {
            if (string.IsNullOrEmpty(newClient.Name))
            {
                throw new Exception("Client can not have empty name"); 
            }
            /// ----- bo tutaj chcesz dodac nowego clienta do bazy danych
            var client =  _mapper.Map<Client>(newClient);
            _clientRepository.Add(client);
            ///// -------------
            //a tu dopiero go mapujesz żeby go używać. 
            return _mapper.Map<ClientDto>(client); // jakbys dal new client to on nie ma nadanego id a przerobienie go na client typu client
            // nadaje mu ID 
        }

        public void UpdateClient (UpdateClientDto updateClient)
        {
            // pobierasz istniejacy client  - mapujesz z update ktory wszedl na nowy product z istniejacego
            // wykonujesz metode update

            var existingClient = _clientRepository.GetById(updateClient.Id);

            var client = _mapper.Map(updateClient, existingClient); // maping musi byc skonfigurowany wczesniej w config AM

            _clientRepository.Update(client);


        }

        public void DeleteClient(int id)
        {
            var clientToDelete = _clientRepository.GetById(id);
            
            _clientRepository.Delete(clientToDelete);
        }

        public void DeleteAllClients()
        {
            _clientRepository.DeleteAllClients();
        }
    }
}
