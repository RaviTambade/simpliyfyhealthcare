using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestWebAPI.Models;

namespace TestWebAPI.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        // Simulating a database with an in-memory list
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Gerbera", Price = 20.0m, Description = "Wedding Flower" },
            new Product { Id = 2, Name = "Rose", Price = 40.0m, Description = "Valentine Flower" },
        };

        // GET: api/products
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            // Simulating async operation
            return Ok(await Task.FromResult(_products));
        }

        // GET: api/products/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(await Task.FromResult(product));
        }

        // POST: api/products
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid data.");
            }

            // Simulating async operation and adding the new product
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        // PUT: api/products/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null || id != product.Id)
            {
                return BadRequest("Product ID mismatch.");
            }

            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Simulating async update
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            return Ok(await Task.FromResult(existingProduct));
        }

        // DELETE: api/products/5
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            // Simulating async delete
            _products.Remove(product);
            return Ok(await Task.FromResult(product));
        }
    }
}
