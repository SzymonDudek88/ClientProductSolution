using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [StringLength(100)]
        public string UserId { get; set; }  // using for check authentication who can menage order
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
