using Application.Dto;
using Application.Dto.Cosmos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICosmosClientService // tu podmieniasz na dto bo pracujesz na dto
    {
       Task < IEnumerable<CosmosClientDto>> GetAllAsync(); // CosmosClientDto

        Task<CosmosClientDto> GetByIdAsync(string id);

        Task<CosmosClientDto> AddNewClientAsync(CreateCosmosClientDto newClient); // bo create nie ma id - id se nadamy

        Task UpdateClientAsync(UpdateCosmosClientDto updateClient);
        Task DeleteClientAsync(string id);
        Task DeleteAllClientsAsync();
    }
}
