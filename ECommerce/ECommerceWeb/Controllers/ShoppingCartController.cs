 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceEntities;
using Specification;
using ECommerceServices;
namespace ECommerceWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        public ActionResult Index()
        {

           
            Cart myCart = (Cart)this.HttpContext.Session["cart"];
           // ICartService svc = new CartService(myCart);
           
           // ViewData["cart"]=myCart;
            return View();
        }
        public ActionResult AddToCart(int id)
        {
            Item item = new Item();
            item.productId = id;
            item.quantity = 0;

            return View(item);
        }

        [HttpPost]
        public ActionResult AddToCart(Item theItem)
        {
            Cart myCart=(Cart) this.HttpContext.Session["cart"];
            myCart.Items.Add(theItem);

            return RedirectToAction("Index", "Products"); ;
        }


        public ActionResult RemoveFromCart(int id)
        {
            Cart myCart = (Cart)this.HttpContext.Session["cart"];
            myCart.Items.RemoveAll((item) => (item.productId == id));
            return RedirectToAction("Index");
        }
        

    }
}