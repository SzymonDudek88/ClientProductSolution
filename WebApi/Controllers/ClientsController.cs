using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService) // domain ->application - > web api
        {
            _clientService = clientService;
        }

        [SwaggerOperation(Summary = "Retrivies all Clients")] //schwackbuckle annotations -> w startup adnotacje wlacz !
        [HttpGet]
        public IActionResult Get()
        {
            var clients = _clientService.GetAll();
            return Ok(clients);

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var client = _clientService.GetById(id);
            if (client == null) return NotFound();
            return Ok(client);

        }

        [HttpPost]

        public IActionResult CreateNewClient(CreateClientDto newClient)
        {
            var client = _clientService.AddNewClient(newClient);

            return Created($"api/Clients/{client.Id}", newClient); // jeszcze przesylasz obiekt!

        }


        [HttpPut]
        public IActionResult UpdateClient(UpdateClientDto clientUpdated)
        {
              _clientService.UpdateClient(clientUpdated);
            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            _clientService.DeleteClient(id);
            return NoContent();
        
        }


    }
}
