using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor httpContext )
        {
            _context = httpContext; 

        }

        public string GetUser()
        {
            return _context.HttpContext.User?.Identity?.Name; // gets the name of current user
            // add it in mvc installer 
        }
    }
}
