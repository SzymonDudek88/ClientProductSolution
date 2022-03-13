//using Application.Dto;
//using Application.Interfaces;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Swashbuckle.AspNetCore.Annotations;

//namespace WebApi.Controllers.V2
//{
//    [ApiExplorerSettings(IgnoreApi = true)]
//    [Route("api/[controller]")]
//    [ApiVersion("2.0")]
//    [ApiController]
//    public class ClientsController : ControllerBase
//    {
//        private readonly IClientService _clientService;

//        public ClientsController(IClientService clientService) // domain ->application - > web api
//        {
//            _clientService = clientService;
//        }

//        [SwaggerOperation(Summary = "Retrivies all Clients")] //schwackbuckle annotations -> w startup adnotacje wlacz !
//        [HttpGet]
//        public IActionResult Get()
//        {
//            var clients = _clientService.GetAll();
//            return Ok(clients);

//        }

//        [HttpGet("{id}")]

//        public IActionResult GetById(int id)
//        {
//            var client = _clientService.GetById(id);
//            if (client == null) return NotFound();
//            return Ok(client);

//        }
//       //// The idea is to generate OData adress to find  smth using this string 
//       ///
//       // [SwaggerOperation(Summary = "Retrivies OData string to find client by name")]
//       // [HttpGet("Search/{city}")] 
//       // public IActionResult GetClientByCity(string city)
//       //  {
//       // return Accepted($"api/Clients/getall/filter=Contains({city})");
//       //  }


//    [HttpPost] 
//        public IActionResult CreateNewClient(CreateClientDto newClient)
//        {
//            var client = _clientService.AddNewClient(newClient);

//            return Created($"api/Clients/{client.Id}", newClient); // jeszcze przesylasz obiekt!

//        }


//        [HttpPut]
//        public IActionResult UpdateClient(UpdateClientDto clientUpdated)
//        {
//              _clientService.UpdateClient(clientUpdated);
//            return NoContent();


//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteClient(int id)
//        {
//          var isExist =   _clientService.GetById(id);

//            if (isExist == null)
//            {
//                return NotFound();
//            }

//            _clientService.DeleteClient(id);
             
//            return NoContent();
        
//        }
//        [SwaggerOperation(Summary = "Delete all clients  ")]
//        [HttpDelete()]
//        public IActionResult DeleteAllClients()
//        {
//             _clientService.DeleteAllClients();

//            return NoContent();

//        }

//    }
//}
