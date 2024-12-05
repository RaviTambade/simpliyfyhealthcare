using Microsoft.AspNetCore.Mvc;
using ProductCatalog;
using ProductCatalog.Repositories;
using ProductCatalog.Entities;


namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlowersController : ControllerBase
    {


        private readonly ILogger<FlowersController> _logger;

        public FlowersController()
        {
        }
        public FlowersController(ILogger<FlowersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = ProductManager.GetAll();
            return products;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllFlowers()
        {
            await Task.Delay(100);
            List<Product> products = ProductManager.GetAll();
            return products;
        }


        [HttpGet("{id}")]
        public async  Task<Product> GetByIdAsync(int id)
        {
            //Si
            await Task.Delay(1000);

           Product theProduct = ProductManager.GetById(id);
            return theProduct;
        }
    }
}
