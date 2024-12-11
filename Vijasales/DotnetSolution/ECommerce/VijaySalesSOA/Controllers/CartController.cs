using Catalog.Entities;
using Newtonsoft.Json;
using ShoppingCart.Entities;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
                // If cart is not found, create a new one and save it in session
                theCart = new Cart();
                this.Session["cart"] = theCart;
            }
            return theCart;
        }

        // GET: Cart
        public ActionResult Index()
        {
            EnableCors(); // Add CORS headers
            Cart theCart = GetCartFromSession();
            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        // POST: Add to Cart
        [System.Web.Http.HttpPost]
        public ActionResult AddToCart()
        {
            EnableCors();  // Add CORS headers

            // Read JSON request body
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

            // Debugging cart state
            System.Diagnostics.Debug.WriteLine("Cart contents before adding item: " + JsonConvert.SerializeObject(theCart));

            theCart.Items.Add(item);  // Add item to cart
            this.Session["cart"] = theCart;  // Save updated cart to session

            // Debugging cart state after adding item
            System.Diagnostics.Debug.WriteLine("Cart contents after adding item: " + JsonConvert.SerializeObject(theCart));

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        // GET: Cart/GetById/5
        [System.Web.Http.HttpGet]
        public ActionResult GetById(int id)
        {
            EnableCors(); // Add CORS headers
            Cart theCart = GetCartFromSession();
            var item = theCart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item == null)
            {
                return Json("Item not found.");
            }

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        // PUT: Cart/PutById/5
        [System.Web.Http.HttpPut]
        public ActionResult PutById(int id)
        {

            EnableCors(); // Add CORS headers
            string jsonString;
            using (var reader = new StreamReader(Request.InputStream))
            {
                jsonString = reader.ReadToEnd();
            }

            int? quantity = JsonConvert.DeserializeObject<int?>(jsonString);

            if (quantity == null)
            {
                return Json("Item not found.");
            }
            Cart theCart = GetCartFromSession();
            var item = theCart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item == null)
            {
                return Json("Item not found.");
            }

            // Update the quantity of the item
            item.Quantity += (int)quantity;
            if (item.Quantity <= 0)
            {
                theCart.Items.Remove(item);
            }

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        // DELETE: Cart/DeleteById/5
        [System.Web.Http.HttpDelete]
        public ActionResult DeleteById(int id)
        {
            EnableCors(); // Add CORS headers
            Cart theCart = GetCartFromSession();
            var item = theCart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item == null)
            {
                return Json("Item not found.");
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
            EnableCors(); // Add CORS headers
            Cart theCart = GetCartFromSession();

            // Clear all items in the cart
            theCart.Items.Clear();

            return Json(theCart, JsonRequestBehavior.AllowGet);
        }

        // GET: Cart/GetItemCount
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Cart/GetItemCount")]
        public ActionResult GetItemCount()
        {
            EnableCors(); // Add CORS headers
            Cart theCart = GetCartFromSession();

            if (theCart == null || !theCart.Items.Any())
            {
                return Json(0, JsonRequestBehavior.AllowGet);  // No items, so return 0
            }

            int totalCount = theCart.Items.Sum(item => item.Quantity);

            return Json(totalCount, JsonRequestBehavior.AllowGet); // Return the total count of items
        }

        public ActionResult ShowCart()
        {
            EnableCors(); // Add CORS headers
            return View();
        }

        // Add CORS headers manually
        private void EnableCors()
        {
            string allowedOrigin = "http://localhost:49997";  // Replace with your frontend's origin
            Response.AppendHeader("Access-Control-Allow-Origin", allowedOrigin); // Set specific origin
            Response.AppendHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type, Authorization");
            Response.AppendHeader("Access-Control-Allow-Credentials", "true"); // Allow credentials (cookies, etc.)
        }

    }
}
