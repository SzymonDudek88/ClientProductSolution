using Application.Dto;
using Application.Interfaces;
using AutoMapper;
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
    }
}
