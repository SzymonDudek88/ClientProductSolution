using Application.Dto;
using Application.Dto.Cosmos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace WebApi.Controllers.V1
{  
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ICosmosClientService _clientService;

        public ClientsController(ICosmosClientService clientService) // domain ->application - > web api
        {
            _clientService = clientService;
        }

        [SwaggerOperation(Summary = "Retrivies all Clients")] //schwackbuckle annotations -> w startup adnotacje wlacz !
        [HttpGet]
        public IActionResult Get()
        {
            var clients = _clientService.GetAllAsync();
            return Ok( clients.Result);

        }

        [HttpGet("{id}")]

        public async Task< IActionResult > GetById(string id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);

        }
       


    [HttpPost] 
        public async Task<IActionResult> CreateNewClient(CreateCosmosClientDto newClient)
        {
            var client = await _clientService.AddNewClientAsync(newClient);

            return Created($"api/Clients/{client.Id}", newClient); // jeszcze przesylasz obiekt!

        }


        [HttpPut]
        public async Task< IActionResult> UpdateClient(UpdateCosmosClientDto clientUpdated)
        {
            await  _clientService.UpdateClientAsync(clientUpdated);
            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task < IActionResult > DeleteClient(string id)
        {
          var isExist =  await _clientService.GetByIdAsync(id);

            if (isExist == null)
            {
                return NotFound();
            }

           await _clientService.DeleteClientAsync(id);
             
            return NoContent();
        
        }
        [SwaggerOperation(Summary = "Delete all clients  ")]
        [HttpDelete()]
        public async Task < IActionResult > DeleteAllClients()
        {
            await _clientService.DeleteAllClientsAsync();

            return NoContent();

        }

    }
}
