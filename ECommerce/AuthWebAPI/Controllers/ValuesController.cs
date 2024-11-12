using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AuthWebAPI.Models;
namespace AuthWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Product> Get()
        {
            return new Product[] {
            new Product { Id = 1, Name = "gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 2000, Image = "/Images/gerbera.jpg" },
            new Product { Id = 2, Name = "rose", Description = "Valentine Flower", UnitPrice = 23, Quantity = 9000, Image = "/images/rose.jpg" }
            };
        }

        // GET api/values/5
        public Product Get(int id)
        {
            return new Product { Id = id, Name = "gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 2000, Image = "/Images/gerbera.jpg" };
        
        }

        // POST api/values
        public void Post([FromBody] Product value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Product value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
