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

        public ActionResult AddToCart(Items id)
        {
            Cart myCart = (Cart)this.HttpContext.Session["cart"];
            ICartService cartService = new CartService(myCart);
            cartService.AddToCart(i);
            return RedirectToAction("Index", "Product");
        }
        public ActionResult AddToCart(int id)
        {
            Items item = new Items();
            item.Id = id;
            item.Quantity = 0;
            item.Name = name;
            ViewData["item"] = item;
            return View(item);

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
