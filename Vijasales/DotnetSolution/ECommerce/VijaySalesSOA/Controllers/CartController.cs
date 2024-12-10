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
        private Cart GetCartFromSession()
        {
            Cart theCart = (Cart)this.Session["cart"];
            if (theCart == null)
            {
                // If cart is not found, create a new one and save it in session
                theCart = new Cart();
                this.Session["cart"] = theCart;
            }
            return theCart;
        }

        // GET: Cart
        public ActionResult Index()
        {
            Cart theCart = GetCartFromSession();
            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        // POST: Add to Cart
        [System.Web.Http.HttpPost]
        public ActionResult AddToCart([FromBody] Product product)
        {
            var item = new Items
            {
                ProductId = product.Id,
                Quantity = 1,
                Price = product.Price
            };

            Cart theCart = GetCartFromSession();
            theCart.Items.Add(item);

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        // GET: Cart/GetById/5
        [System.Web.Http.HttpGet]
        public ActionResult GetById(int id)
        {
            Cart theCart = GetCartFromSession();
            var item = theCart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item == null)
            {
                return HttpNotFound("Item not found.");
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        // PUT: Cart/PutById/5
        [System.Web.Http.HttpPut]
        public ActionResult PutById(int id, [FromBody] int quantity)
        {
            Cart theCart = GetCartFromSession();
            var item = theCart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item == null)
            {
                return HttpNotFound("Item not found.");
            }

            // Update the quantity of the item
            item.Quantity = quantity;

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        // DELETE: Cart/DeleteById/5
        [System.Web.Http.HttpDelete]
        public ActionResult DeleteById(int id)
        {
            Cart theCart = GetCartFromSession();
            var item = theCart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item == null)
            {
                return HttpNotFound("Item not found.");
            }

            // Remove the item from the cart
            theCart.Items.Remove(item);

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        // DELETE: Cart/DeleteAll
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("Cart/DeleteAll")]
        public ActionResult DeleteAll()
        {
            Cart theCart = GetCartFromSession();

            // Clear all items in the cart
            theCart.Items.Clear();

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

    }
}