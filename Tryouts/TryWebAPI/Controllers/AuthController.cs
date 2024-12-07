using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;


namespace TryWebAPI.Controllers
{

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login([FromBody] LoginModel login)
        {
            // Dummy validation, replace with actual user validation
            if (login.Username == "ravi" && login.Password == "seed")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["JwtSecret"]);
                var claims = new[] {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, "User") // Add more claims as needed
                };
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = System.Configuration.ConfigurationManager.AppSettings["JwtIssuer"],
                    Audience = System.Configuration.ConfigurationManager.AppSettings["JwtAudience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return Ok(new { token = jwtToken });
            }
            return Unauthorized();
        }

    }
}
