using System.Collections.Generic;
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
        public async Task< List<Product>> Get()
        {
            IProductService _productService=new ProductService();
            var products = await _productService.GetAllAsync();
            return products;
             
        }

        // GET api/products/5
        [HttpGet]
        public async Task<Product>  Get(int id)
        {
            IProductService _productService = new ProductService();

            var product = await _productService.GetAsync(id);
            if (product == null)
            {
                return null ;
            }
            return product;
        }

        // GET api/products/category/{category}
        [HttpGet]
        public async void  GetByCategory(string category)
        {
            IProductService _productService = new ProductService();

            var products = await _productService.GetByCategoryAsync(category);
            return;  
        }

        // POST api/products
        [HttpPost]
        public async void Post([FromBody] Product product)
        {
            if (product == null)
            {
                return;  // Returns 400 Bad Request if the product is null
            }
            IProductService _productService = new ProductService();

            var success = await _productService.InsertAsync(product);
            if (!success)
            {
                    return;  // Returns 400 Bad Request if insertion fails
            }
            return ;  // Returns 200 OK if the product is successfully created
        }

        // PUT api/products/5
        [HttpPut]
        [Route("{id=int}")]
        public async Task<IHttpActionResult> Update (int id, [FromBody] Product product)
        {
            
            IProductService _productService = new ProductService();

            var updatedProduct = await _productService.UpdateAsync(product); 
            
            return Ok(updatedProduct);
        }

        // DELETE api/products/5
        [HttpDelete]
        public async void Delete(int id)
        {
            IProductService _productService = new ProductService();

            var success = await _productService.DeleteAsync(id);
            
            return;
        }
    }
}
