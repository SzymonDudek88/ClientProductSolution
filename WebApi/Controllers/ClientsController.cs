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



    }
}
