using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Clients")]
    public class Client : AuditibleEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        public Client()
        {

        }

        public Client(int id, string name, string city)
        {
            Id = id;
            Name = name;    
            City = city;
        }
    }
}
