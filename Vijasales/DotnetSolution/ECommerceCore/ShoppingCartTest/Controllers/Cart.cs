using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartTest.Controllers
{
    public class Cart : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
