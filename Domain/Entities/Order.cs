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
        public int ProductId { get; set; }
        public int ClientId { get; set; }

        public int OrderQuantity { get; set; }
        public Order( int id , int productId, int clientId, int orderQuantity  )
        {
            Id = id;
            ProductId = productId;
            ClientId = clientId;
            OrderQuantity = orderQuantity;
        }
        public Order()
        {

        }
    }
}
