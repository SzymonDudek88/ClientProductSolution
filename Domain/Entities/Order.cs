using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Order : AuditibleEntity
    {
        public int Id { get; set; }
        public Product OrderedProduct { get; set; }
        public Client OrderingClient { get; set; }
        public Order( int id , Product product, Client client)
        {
            Id = id;
            OrderedProduct = product;
            OrderingClient = client;
        }
    }
}
