using Application.Dto;
using Application.Dto.Cosmos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace WebApi.Controllers.V1
{
    [ApiExplorerSettings(IgnoreApi = true)] // using v2 cuz dont want use cosmos now
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class CosmosClientController : ControllerBase
    {
        private readonly ICosmosClientService _clientService;

        public CosmosClientController(ICosmosClientService clientService) // domain ->application - > web api
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

        [SwaggerOperation(Summary = "Get Client by id")]
        [HttpGet("{id}")]
        public async Task< IActionResult > GetById(string id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);

        }


        [SwaggerOperation(Summary = "Create new Client")]
        [HttpPost] 
        public async Task<IActionResult> CreateNewClient(CreateCosmosClientDto newClient)
        {
            var client = await _clientService.AddNewClientAsync(newClient);

            return Created($"api/Clients/{client.Id}", newClient); // jeszcze przesylasz obiekt!

        }

        [SwaggerOperation(Summary = "Update existing Client")]
        [HttpPut]
        public async Task< IActionResult> UpdateClient(UpdateCosmosClientDto clientUpdated)
        {
            await  _clientService.UpdateClientAsync(clientUpdated);
            return NoContent();


        }
        [SwaggerOperation(Summary = "Delete Client by id")]
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
        [SwaggerOperation(Summary = "Delete all Clients")]
        [HttpDelete()]
        public async Task < IActionResult > DeleteAllClients()
        {
            await _clientService.DeleteAllClientsAsync();

            return NoContent();

        }

    }
}
