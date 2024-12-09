using Catalog.Entities;
using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace VijaySalesSOA.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Cart theCart = (Cart)this.Session["cart"];

            return Json(theCart,JsonRequestBehavior.AllowGet);
            }

        [System.Web.Http.HttpPost]
        public ActionResult AddtoCart([FromBody]Product product) {
            var item = new Items

            {

                ProductId = product.Id,

                Quantity = 1,

                Price = product.Price

            };
            Cart theCart = (Cart)this.Session["cart"];
            theCart.Items.Add(item);
            return Json(theCart, JsonRequestBehavior.AllowGet);

        }
    }
}