using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Catalog.Entities;
using Catalog.Services;
using System.Web.Http.Cors;


namespace VijaySalesSOA.Controllers
{
    [EnableCors(origins: "http://localhost:49997", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            IProductService _productService = new ProductService();
            var products = await _productService.GetAllAsync();

            // Simulating async operation
            return Ok(await Task.FromResult(products));
        }

        // GET: api/Products/5
        [HttpGet]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            IProductService _productService = new ProductService();

            var product = await _productService.GetAsync(id);


            return Ok(await Task.FromResult(product));
        }
        // POST: api/Products
        [HttpPost]
        public async Task<IHttpActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid data.");
            }


            IProductService _productService = new ProductService();

            var success = await _productService.InsertAsync(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut]
        public async Task<IHttpActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null || id != product.Id)
            {
                return BadRequest("Product ID mismatch.");
            }
            IProductService _productService = new ProductService();

            var updatedProduct = await _productService.UpdateAsync(product);

            return Ok(updatedProduct);

            // return Ok(await Task.FromResult(existingProduct));
        }

        // DELETE: api/Products/5
        [HttpDelete]
        
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            IProductService _productService = new ProductService();

            var success = await _productService.DeleteAsync(id);

            var product = await _productService.GetAsync(id);

            return Ok(await Task.FromResult(product));
        }
    }
}
