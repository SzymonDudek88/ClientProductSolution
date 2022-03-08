using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateOrderDto
    {
        public Product OrderedProduct { get; set; } // na dto?
        public Client OrderingClient { get; set; }  // na dto ? 
    }
}
