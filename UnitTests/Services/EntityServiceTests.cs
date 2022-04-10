using Application.Dto.Cosmos;
using Application.Services;
using AutoMapper;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Services
{
    public class EntityServiceTests
    {

        [Fact]
        public async Task add_client_async_should_invoke_add_async_on_client_repository()
        {
            // Arrange
            var cosmosClientRepositoryMock = new Mock<ICosmosClientRepository>();
            var mapperMock = new Mock<IMapper>();


            var cosmosClientService = new CosmosClientService(cosmosClientRepositoryMock.Object, mapperMock.Object);

            var createCosmosClientDto = new CreateCosmosClientDto()
            {
                Name = "Luk",
                City = "Oil"
            };

            mapperMock.Setup(x => x.Map<CosmosClient>(createCosmosClientDto)).Returns(new CosmosClient() {
              Name=  createCosmosClientDto.Name,
              City =   createCosmosClientDto.City
               }); // tu ustalasz co ma mapowac i co wlasciwie powinno zwrocic jako Returns - czyli wszystko reczne jesdt

        
            //// Act
             await cosmosClientService.AddNewClientAsync(createCosmosClientDto );

            //// Assert

           cosmosClientRepositoryMock.Verify(x => x.Add(It.IsAny<CosmosClient>()), Times.Once);
            
        }
    }
}
 
