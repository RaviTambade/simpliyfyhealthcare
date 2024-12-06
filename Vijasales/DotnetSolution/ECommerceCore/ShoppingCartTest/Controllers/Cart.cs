using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCartTest.Models;
using Microsoft.AspNetCore.Http;

namespace ShoppingCartTest.Controllers
{
    public class CartController : Controller
    {
        private const string SessionCartKey = "_Cart";

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult GetCart()
        {
            // Retrieve the cart from session
            var cart = GetCartFromSession();

            if (cart == null || cart.Items.Count == 0)
            {
                ViewData["Message"] = "Your cart is empty.";
            }

            return View(cart);
        }

        // POST: Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(IFormCollection form)
        {
            // Parse the form data to get item details
            int id = int.Parse(form["Id"]);
            string name = form["Name"];
            int quantity = int.Parse(form["Quantity"]);

            // Create a new item and set its properties
            var item = new Items
            {
                Id = id,
                Name = name,
                Quantity = quantity
            };

            // Retrieve the cart from session, or create a new cart if it doesn't exist
            var cart = GetCartFromSession() ?? new Cart();


            cart.Items.Add(item);

            // Save the updated cart 
            SetCartInSession(cart);


            return RedirectToAction("GetCart");
        }


        public IActionResult RemoveFromCart(int id)
        {
            // Retrieve the cart from session
            var cart = GetCartFromSession();

            if (cart != null)
            {
                // Find and remove the item by ID
                var itemToRemove = cart.Items.Find(i => i.Id == id);
                if (itemToRemove != null)
                {
                    cart.Items.Remove(itemToRemove);
                    SetCartInSession(cart); // Save the updated cart back to session
                }
            }


            return RedirectToAction("GetCart");
        }


        public IActionResult Clear()
        {
            // Remove the cart from session
            HttpContext.Session.Remove(SessionCartKey);


            return RedirectToAction("GetCart");
        }

        // Helper method to get the cart from session
        private Cart GetCartFromSession()
        {
            var cartJson = HttpContext.Session.GetString(SessionCartKey);
            if (cartJson == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Cart>(cartJson);
        }

        // Helper method to save the cart in session
        private void SetCartInSession(Cart cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString(SessionCartKey, cartJson);
        }
    }
}