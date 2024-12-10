using Microsoft.AspNetCore.Mvc;
using ProductCatalogueTest.Models;


namespace ProductCatalogueTest.Controllers
{
    public class ProductsController : Controller
    {

       
        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult Details(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        public IActionResult Management()
        {
            return View();
        }
    }
}
