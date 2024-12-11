using Catalog.Entities;
using Newtonsoft.Json;
using ShoppingCart.Entities;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace VijaySalesSOA.Controllers
{
    public class CartController : Controller
    {
        private Cart GetCartFromSession()
        {
            Cart theCart = (Cart)this.Session["cart"];
            if (theCart == null)
            {
                theCart = new Cart();
                this.Session["cart"] = theCart;
            }
            return theCart;
        }

        public ActionResult Index()
        {
            EnableCors();
            Cart theCart = GetCartFromSession();
            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public ActionResult AddToCart()
        {
            EnableCors();
            string jsonString;
            using (var reader = new StreamReader(Request.InputStream))
            {
                jsonString = reader.ReadToEnd();
            }

            Product product = JsonConvert.DeserializeObject<Product>(jsonString);

            if (product == null)
            {
                return Json(new { success = false, message = "Invalid product data" }, JsonRequestBehavior.AllowGet);
            }

            var item = new Items
            {
                ProductId = product.Id,
                Quantity = 1,
                Price = product.Price
            };

            Cart theCart = GetCartFromSession();
            theCart.Items.Add(item);
            this.Session["cart"] = theCart;

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public ActionResult GetById(int id)
        {
            EnableCors();
            Cart theCart = GetCartFromSession();
            var item = theCart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item == null)
            {
                return Json("Item not found.");
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPut]
        public ActionResult PutById(int id)
        {
            EnableCors();
            string jsonString;
            using (var reader = new StreamReader(Request.InputStream))
            {
                jsonString = reader.ReadToEnd();
            }

            int? quantityChange = JsonConvert.DeserializeObject<int?>(jsonString);

            if (quantityChange == null)
            {
                return Json("Invalid quantity change.");
            }

            Cart theCart = GetCartFromSession();
            var item = theCart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item == null)
            {
                return Json("Item not found.");
            }

            // Update the quantity of the item
            item.Quantity += quantityChange.Value;

            if (item.Quantity <= 0)// if quantity is less remove item 
            {
                theCart.Items.Remove(item); // Remove item if quantity is 0 or less
            }

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpDelete]
        public ActionResult DeleteById(int id)
        {
            EnableCors();
            Cart theCart = GetCartFromSession();
            var item = theCart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item == null)
            {
                return Json("Item not found.");
            }

            theCart.Items.Remove(item);

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("Cart/DeleteAll")]
        public ActionResult DeleteAll()
        {
            EnableCors();
            Cart theCart = GetCartFromSession();
            theCart.Items.Clear();

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Cart/GetItemCount")]
        public ActionResult GetItemCount()
        {
            EnableCors();
            Cart theCart = GetCartFromSession();

            if (theCart == null || !theCart.Items.Any())
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

            int totalCount = theCart.Items.Sum(item => item.Quantity);

            return Json(totalCount, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowCart()
        {
            EnableCors();
            return View();
        }

        private void EnableCors()
        {
            string allowedOrigin = "http://localhost:49997";
            Response.AppendHeader("Access-Control-Allow-Origin", allowedOrigin);
            Response.AppendHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type, Authorization");
            Response.AppendHeader("Access-Control-Allow-Credentials", "true");
        }
    }
}
