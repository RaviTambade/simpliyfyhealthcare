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
        public List<User> Get()
        {
            
            List<User> users = _userService.GetAll();
            return users;
        }
        [HttpGet("{id}")]
        public User Get(int id) 
        { 
            User user=_userService.GetUser(id);
            return user;
         }
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.Insert(user);
        }
        [HttpPut]
        public void Put([FromBody] User user)
        {
            _userService.Update(user);  
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }

    }
}
