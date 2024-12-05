using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCartTest.Models;
using Microsoft.AspNetCore.Http;

namespace ShoppingCartTest.Controllers
{
<<<<<<< HEAD
    public class CartController : Controller
    {
        private const string SessionCartKey = "_Cart";
=======
<<<<<<< HEAD
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
           
        }


        [HttpPost]
        public ActionResult AddToCart(IFormCollection f)
        {
            int id = int.Parse(f["Id"]);
            string Name = f["Name"];
            int Quantity = int.Parse(f["Quantity"]);
            Items i=new Items();
            i.Id = id;
            i.Name = Name;
            i.Quantity = Quantity;
            ViewData["item"] = i;
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

=======
>>>>>>> 009ef1d72f44e5ad780c961b439d9c4a95bcb6c2

        
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
<<<<<<< HEAD
=======
>>>>>>> b0c17e237b863f7216a7b86c16fa089738de0f31
    }
>>>>>>> 009ef1d72f44e5ad780c961b439d9c4a95bcb6c2

       
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
