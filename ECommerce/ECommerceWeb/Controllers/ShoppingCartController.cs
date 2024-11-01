using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart()
        {
            return View();
        }

        public ActionResult RemoveFromCart()
        {
            return View();
        }
        

    }
}