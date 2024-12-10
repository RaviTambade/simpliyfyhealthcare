using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using ShoppingCart.Entities;
using VijaySalesAPI.Filters;
using Catalog.Entities;

namespace VijaySalesAPI.Controllers
{
    [SessionState]  // Custom filter to enable session in Web API controller
    public class ShoppingCartController : ApiController
    {
        private const string SessionCartKey = "_Cart";

        // GET: api/ShoppingCart
        [HttpGet]
        public Cart Get()
        {
            // Access session
            Cart cart = (Cart)HttpContext.Current.Session["cart"];

            if (cart == null || !cart.Items.Any())
            {
                return new Cart();  // Return an empty cart if no items
            }

            return cart;  // Return the full cart object
        }

        // GET api/ShoppingCart/5
        [HttpGet]
        public string Get(int id)
        {
            // Access session
            Cart myCart = (Cart)HttpContext.Current.Session["cart"];

            if (myCart == null)
            {
                return "Cart not found.";
            }

            var item = myCart.Items.FirstOrDefault(i =>i.ProductId == id);
            if (item == null)
            {
                return "Item not found in the cart.";
            }
           
            return $"ProductId: {item.ProductId}, Quantity: {item.Quantity}, Price: {item.Price}";
        }

        // POST api/ShoppingCart
        [HttpPost]
       public IHttpActionResult Post([FromBody] Product product)
        {
            if (product == null || product.Price <= 0 || product.Stock <= 0)
            {
                return BadRequest("Invalid product.");
            }

            var item = new Items
            {
                ProductId = product.Id,
                Quantity = 1,
                Price = product.Price
            };

            // Access session
            Cart myCart = (Cart)HttpContext.Current.Session["cart"];

            if (myCart == null)
            {
                myCart = new Cart();
                HttpContext.Current.Session["cart"] = myCart;  // Create a new cart if it doesn't exist
            }

            // Check if the item already exists in the cart
            var existingItem = myCart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;  // If exists, update quantity
            }
            else
            {
                myCart.Items.Add(item);  // Otherwise, add new item to the cart
            }

            return Ok(new { message = "Item added to cart!" });
        }

        // PUT api/ShoppingCart/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] int quantity)
        {
            // Access session
            Cart myCart = (Cart)HttpContext.Current.Session["cart"];

            if (myCart == null)
            {
                return NotFound();  // Cart not found
            }

            var existingItem = myCart.Items.FirstOrDefault(i => i.ProductId == id);
            if (existingItem == null)
            {
                return NotFound();  // Item not found in the cart
            }

            // Update the quantity of the item
            existingItem.Quantity = quantity;

            return Ok(new { message = "Item quantity updated!" });
        }

        // DELETE api/ShoppingCart/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            // Access session
            Cart myCart = (Cart)HttpContext.Current.Session["cart"];

            if (myCart == null)
            {
                return NotFound();  // Cart not found
            }

            var itemToRemove = myCart.Items.FirstOrDefault(i => i.ProductId == id);
            if (itemToRemove == null)
            {
                return NotFound();  // Item not found
            }

            myCart.Items.Remove(itemToRemove);  // Remove item from the cart

            return Ok(new { message = "Item removed from cart!" });
        }

        // DELETE api/ShoppingCart/clear
        [HttpDelete]
        [Route("api/ShoppingCart/clear")]
        public IHttpActionResult Clear()
        {
            // Remove the cart from session
            HttpContext.Current.Session.Remove(SessionCartKey);

            return Ok(new { message = "Cart cleared!" });
        }

    }
        
    }