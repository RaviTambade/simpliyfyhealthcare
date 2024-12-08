using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
       public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _productService.GetAllAsync(); 
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productService.GetAsync(id); 
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // GET api/<ProductsController>/category
        [HttpGet("category/{category}")]
        public async Task<ActionResult<List<Product>>> GetByCategory(string category)
        {
            var products = await _productService.GetByCategoryAsync(category);
            return Ok(products);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var success = await _productService.InsertAsync(product); 
            if (!success)
            {
                return BadRequest("Product could not be inserted.");
            }
            return Ok();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            if (product == null )
            {
                return BadRequest();
            }

            var updatedProduct = await _productService.UpdateAsync(product); 
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return Ok(updatedProduct);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productService.DeleteAsync(id); 
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
