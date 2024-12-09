using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using Catalog.Entities;  // Ensure this is the correct namespace where Product is defined
using Catalog.Services; // Assuming _productService is in this namespace

namespace VijaySalesAPI.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {


        // GET: api/products
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            IProductService _productService = new ProductService();
            var products = await _productService.GetAllAsync();
            
            // Simulating async operation
            return Ok(await Task.FromResult(products));
        }

        // GET: api/products/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            IProductService _productService = new ProductService();

            var product = await _productService.GetAsync(id);
            

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

         
            IProductService _productService = new ProductService();

            var success = await _productService.InsertAsync(product);
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
            IProductService _productService = new ProductService();

            var updatedProduct = await _productService.UpdateAsync(product);

            return Ok(updatedProduct);

           // return Ok(await Task.FromResult(existingProduct));
        }

        // DELETE: api/products/5
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            IProductService _productService = new ProductService();

            var success = await _productService.DeleteAsync(id);

           var product=await _productService.GetAsync(id);
            return Ok(await Task.FromResult(product));
        }
    }
   

       /*

        // GET api/products/category/{category}
        [HttpGet]
        public async void  GetByCategory(string category)
        {
            IProductService _productService = new ProductService();

            var products = await _productService.GetByCategoryAsync(category);
            return;  
        }
       */
     

    
       
      

    }

