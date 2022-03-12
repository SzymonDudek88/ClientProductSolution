using Cosmonaut.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Cosmos
{
    [CosmosCollection("clients")]
    public  class CosmosClient
    {  
        [CosmosPartitionKey]
        [JsonProperty]
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public CosmosClient()
        {

        }

        public CosmosClient(string id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }
    }
}
