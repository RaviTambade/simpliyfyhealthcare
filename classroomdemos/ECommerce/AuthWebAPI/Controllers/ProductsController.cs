using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ECommerceEntities;
using Specification;
using ECommerceServices;
 
namespace AuthWebAPI.Controllers
{
    public class ProductsController : ApiController
    {

        //CRUD Operation: 
        //C:CREATE, R:Read, U:update, D:delete

        // GET api/products
        public IEnumerable<Product> Get()
        {
            IProductService svc=new ProductService();
            List<Product> products = svc.GetAll();
            return products;
        }

        // GET api/products/5
        public Product Get(int id)
        {
            IProductService svc = new ProductService();
            Product product = svc.Get(id);
            return product;

        }

        // POST api/products
        public void Post([FromBody] Product product)
        {
            IProductService svc = new ProductService();
            svc.Insert(product);
        }

        // PUT api/products/5
        public void Put(int id, [FromBody] Product product)
        {
            IProductService svc = new ProductService();
            svc.Update(product);
        }

        // DELETE api/products/5
        public void Delete(int id)
        {
            IProductService svc = new ProductService();
            svc.Delete(id);
        }
    }
}
