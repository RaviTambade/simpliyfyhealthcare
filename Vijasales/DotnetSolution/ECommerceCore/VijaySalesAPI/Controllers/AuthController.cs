using CRM.Models;
using CRM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authsvc;
        public AuthController(IAuthService svc)
        {
            _authsvc = svc;
        }
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticateRequest creds)
        {
     

             var res = await _authsvc.Authenticate(creds);
            if (res == null)
            {
                return StatusCode(400, "user no found");
            }
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // Cookie is not accessible via JavaScript
                Secure = true,   // Set to true in production (use HTTPS)
                SameSite = SameSiteMode.Strict, // Prevent CSRF attacks
                Expires = DateTime.UtcNow.AddHours(1) // Set expiration for the cookie
            };


            return Ok(res);

        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Secret()
        {
            return Ok("Secret found");
        }
       

    }
}
