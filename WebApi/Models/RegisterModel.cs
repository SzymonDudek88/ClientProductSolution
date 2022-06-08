using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Email   { get; set; }
        public string Password { get; set; }
        public string City { get; set; } = "New York";
    }
}
