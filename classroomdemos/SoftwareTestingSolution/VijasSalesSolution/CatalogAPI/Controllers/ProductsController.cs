using Microsoft.AspNetCore.Mvc;
using ProductCatalog;
using ProductCatalog.Repositories;
using ProductCatalog.Entities;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

      /*  public ProductsController()
        {
        }
      */

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = ProductManager.GetAll();
            return products;
        }


        [HttpGet("{id}")]
        public Product GetById(int id)
        {
           Product theProduct = ProductManager.GetById(id);
            return theProduct;
        }
    }
}
