using CatalogAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private  List<Customer> _customers = new List<Customer>();

         public CustomersController() {
            _customers.Add(new Customer { Id = 12, Email = "charan.kumar@transflower.in", Location = "Delhi", ContactNumber = "9223659384" });
            _customers.Add(new Customer { Id = 13, Email = "ganesh.shinde@transflower.in", Location = "Pune", ContactNumber = "9223659376" });
            _customers.Add(new Customer { Id = 14, Email = "pragati.bangar@transflower.in", Location = "Mumbai", ContactNumber = "9226879384" });
            _customers.Add(new Customer { Id = 15, Email = "manish.patil@transflower.in", Location = "Nagpur", ContactNumber = "9227658384" });
            _customers.Add(new Customer { Id = 16, Email = "sham.more@transflower.in", Location = "Nashik", ContactNumber = "9223659496" });
            _customers.Add(new Customer { Id = 17, Email = "karan.kapoor@transflower.in", Location = "Kolhapur", ContactNumber = "9223658764" });
        }

        // GET: api/customers
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customers);
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var todoItem = _customers.FirstOrDefault(t => t.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        // POST: api/customers
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            customer.Id = _customers.Count + 1;
            _customers.Add(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer updatedCustomer)
        {
            var existingCustomer = _customers.FirstOrDefault(t => t.Id == id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.ContactNumber = updatedCustomer.ContactNumber;
            existingCustomer.Location= updatedCustomer.Location;
            return this.Ok();
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customerToRemove = _customers.FirstOrDefault(t => t.Id == id);
            if (customerToRemove == null)
            {
                return NotFound();
            }
            _customers.Remove(customerToRemove);
            return Ok();
        }
    }
}
