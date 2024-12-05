using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartTest.Models;

namespace ShoppingCartTest.Controllers
{
    public class Cart : Controller
    {
        public ActionResult Index()
        {
            return View();
           
        }
        [HttpPost]

        public ActionResult AddToCart(Items i)
        {
            return View();
        }
        public ActionResult AddToCart(int id)
        {
            return View();

        }

        public ActionResult RemoveFromCart(int id)
        {
            return View();
        }
        public ActionResult Clear()
        {
            return View();
        }

    }
}
