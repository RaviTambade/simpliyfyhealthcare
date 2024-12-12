using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace VijaySalesPortal.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetCart()
        {

            return View();
        }
    }
}
