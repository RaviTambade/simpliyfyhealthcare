using Catalog.Entities;
using Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Controllers
{
    public class ProductsController : Controller
    {
        IProductService _service;
        public ProductsController(IProductService service) {
            this._service = service;

        }
        public IActionResult Index()
        {
            List<Product> products=_service.GetAll();
            ViewData["products"]=products;
            return View();
        }
    }
}
