using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : AuditibleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
