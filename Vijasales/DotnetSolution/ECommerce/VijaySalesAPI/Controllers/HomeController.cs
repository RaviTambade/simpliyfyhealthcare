using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VijaySalesAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult OrderDetails()
        {
            ViewBag.Title = "Home Page";

            return View("CustomerOrderDetails");
        }

        public ActionResult OrderSummary()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult PastOrders()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
     private const string SessionCartKey = "_Cart";

            // GET: api/<ShoppingCartController>
            [HttpGet]

            public Cart Get()
            {
            Cart myCart = (Cart)this.HttpContext.Session["cart"];

            if (cart == null || !cart.Items.Any())
                {
                    return new Cart();  // Return an empty cart if no items
                }

                return mycart;  // Return the full cart object
            }
            // GET api/<ShoppingCartController>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
            Cart myCart = (Cart)this.HttpContext.Session["cart"];

            if (cart == null)
                {
                    return "Cart not found.";
                }

                var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
                if (item == null)
                {
                    return "Item not found in the cart.";
                }

                return $"ProductId: {item.ProductId}, Quantity: {item.Quantity}, Price: {item.Price}";
            }

            // POST api/<ShoppingCartController>
            [HttpPost]
            public IActionResult Post([FromBody] Product product)
            {
                if (product == null || product.Price <= 0 || product.Stock <= 0)
                {
                    return BadRequest("Invalid product data.");
                }


                var item = new Items
                {
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price
                };


            Cart myCart = (Cart)this.HttpContext.Session["cart"];

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
                if (existingItem != null)
                {
                    // If item exists, update the quantity
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    // Otherwise, add the new item to the cart
                    cart.Items.Add(item);
                }

               // SetCartInSession(cart);


                return Ok(new { message = "Item added to cart!" });
            }

            // PUT api/<ShoppingCartController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] int quantity)
            {

            Cart myCart = (Cart)this.HttpContext.Session["cart"];
            //var cart = GetCartFromSession();

                if (cart == null)
                {
                    return; // Cart not found, do nothing.
                }

                var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == id);
                if (existingItem == null)
                {
                    return; // Item not found, do nothing.
                }

                // Update the quantity of the item
                existingItem.Quantity = existingItem.Quantity + quantity;
                //SetCartInSession(cart);
            }

            // DELETE api/<ShoppingCartController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            Cart myCart = (Cart)this.HttpContext.Session["cart"];
            //var cart = GetCartFromSession();

                if (cart == null)
                {
                    return; // Cart not found, do nothing.
                }

                var itemToRemove = cart.Items.FirstOrDefault(i => i.ProductId == id);
                if (itemToRemove == null)
                {
                    return; // Item not found, do nothing.
                }

                cart.Items.Remove(itemToRemove);
                //SetCartInSession(cart);
            }

            // DELETE api/<ShoppingCartController>/clear
            [HttpDelete]
            public void Clear()
            {
                // Remove the cart from session
                HttpContext.Session.Remove(SessionCartKey);
            }

            // GET api/<ShoppingCartController>/count
            [HttpGet("count")]
            public int GetItemCount()
            {
            Cart myCart = (Cart)this.HttpContext.Session["cart"];
            //var cart = GetCartFromSession();
                if (cart == null || !cart.Items.Any())
                {
                    return 0; // If no items, return 0 count.
                }

                return cart.Items.Sum(item => item.Quantity);
            }

       
        }
    }

