using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRM.Services;
using CRM.Entities;

namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task <ActionResult< List<User>>> GetAsync()
        {

            List<User> users = await _userService.GetAllAsync();
            return users;
        }
        [HttpGet("{id}")]
        public async Task  <ActionResult<User>> Get(int id) 
        { 
            User user= await _userService.GetUserAsync(id);
            return user;
         }
        [HttpPost("register")]
        public async Task <IActionResult> Post([FromBody] User user)
        {    
          if (user == null)
            {
                return BadRequest();
            }
            var success=await _userService.InsertAsync(user);
            if (!success)
            {
                return BadRequest("Users cannot be inserted");
            }
            return Ok();
        }
        [HttpPut]
        public  async Task <IActionResult> Put([FromBody] User user)
        {   if (user == null)
            {
                return BadRequest();
            }
            var updatedUser=await _userService.UpdateAsync(user);  
            if(updatedUser==null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var success= await _userService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
