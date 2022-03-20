using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Wrappers;

namespace WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        public IdentityController(UserManager<ApplicationUser> userManager, IConfiguration configuration) //Iconfiguration pozwala pobierac dane z appsetiings JSON
        {
            _configuration = configuration;
            _userManager = userManager;     
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel register)
        { 
        var userExist = await _userManager.FindByNameAsync(register.UserName);
            if (userExist != null)
            {
                return StatusCode  (StatusCodes.Status500InternalServerError, new Response<bool>
                {
                    Success = false, 
                    Message = "User already exists"
                
                
                });

                // jezeli nie istnieje...
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = register.Email, // user name, security stamp i Id zawarte w dziedziczeniu klasy Appuser 
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.UserName 
            };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
                {
                    Success = false,
                    Message = "User creation failed, check user details",
                    Errors = result.Errors.Select(x => x.Description )

                });
            }
            // jezeli udalo sie dodac - 200 ok

            return Ok(new Response<bool>
            { 
            Success = true,
            Message = "User created"
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName); // znajduje usera w db

            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password)) // checkin password
            {
                // if passed genereting token 
                var authClaims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id)  ,  // to lekcja 7 - odnoscie identyfikastora uzytkownika 
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(2), // waznosc 
                    claims: authClaims, // oswiadczenia 
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256) 
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                } );
                 
            }
            
            // jezeli nie jest to
            return Unauthorized();
        }
    }
}
