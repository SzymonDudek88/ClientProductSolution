using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Orders")]
    public  class Order : AuditibleEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
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
