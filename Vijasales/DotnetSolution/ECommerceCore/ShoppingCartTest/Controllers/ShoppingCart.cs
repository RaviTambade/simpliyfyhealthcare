using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartTest.Controllers
{
    public class ShoppingCart : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
