using Application.Dto.Cosmos;
using Domain.Entities.Cosmos;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using WebApi.Wrappers;
using Xunit;

namespace EndToEndTests.Controllers
{
    public class ClientCosmosControllerTests
    {
        private readonly TestServer _server; // uruchomienie api w pamieci 
        private readonly HttpClient _client;
        public ClientCosmosControllerTests()
        {
            // arrange https://stackoverflow.com/questions/41382978/appsettings-json-for-integration-test-in-asp-net-core
            var projectDir = Helper.GetProjectPath("", typeof(Startup).GetTypeInfo().Assembly);
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json")
                    .Build()
                )
                .UseStartup<Startup>());
            // tego nie bylo i byl blad:
            _client = _server.CreateClient();
            
        }
        [Fact]
        public async Task fetching_clients_should_return_not_empty_collection()
        {
            //act
            var response = await _client.GetAsync(@"api/Clients");// nazwa controllera bez controller 
            var content = await response.Content.ReadAsStringAsync();
          //  var pagedResponse = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<CosmosClientDto>>>(content);

            //assert

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);

            content.Should().NotBeEmpty();

            // test sprawdza czy zapytanie na adres api clients zwroci nie pusta kolekcje oraz
            // odpowiednia odpowiedz OK

            // byl blad null reference - nie byla utworzona instancja httpclient
        }
    }
}
