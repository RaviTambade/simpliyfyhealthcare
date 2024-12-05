using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SimpleController : ControllerBase
    {
        public SimpleController()
        {

        }

        [HttpGet("transflower")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var items = new List<string> { "Gerbera", "Rose", "Jasmine" };
            return Ok(items);
        }



        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            // Your logic to fetch the value based on id
            return "simple";
        }
    }
}
