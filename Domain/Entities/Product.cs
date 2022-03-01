using Domain.Common;

namespace Domain.Entities
  
{
    public class Product : AuditibleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int Quantity { get; set; }

        public Product()
        {

        }
        public Product(int id, string name, int price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

  
}
