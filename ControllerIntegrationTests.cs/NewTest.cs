using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApi;
using WebApi.Wrappers;
using Xunit;

namespace RestaurantSDIntegrationTests.ControllerTests
{
    public class ControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ControllerTest()
        {
            var projectDir = ControllerTestHelper.GetProjectPath("", typeof(Startup).GetTypeInfo().Assembly);
            _server = new TestServer(new WebHostBuilder()
                 .UseEnvironment("Development")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                     .SetBasePath(projectDir)
                   .AddJsonFile("appsettings.json") // sure this?
                    .Build()
                )
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task CheckIfReturnNotEmptyWhenAskForListedRestaurants()
        {
            var response = await _client.GetAsync("/api/clients");

            var content = await response.Content.ReadAsStringAsync();

          //  var pagedResponse = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<ClientDto>>>(content);

            response.Should().BeEquivalentTo(HttpStatusCode.OK);

        }
    }
}
