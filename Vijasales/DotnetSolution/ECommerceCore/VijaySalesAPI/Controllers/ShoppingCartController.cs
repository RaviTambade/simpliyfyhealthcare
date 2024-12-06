using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private const string SessionCartKey = "_Cart";

        // GET: api/<ShoppingCartController>
        [HttpGet]
    
       public Cart Get()
        {
            var cart = GetCartFromSession();

            if (cart == null || !cart.Items.Any())
            {
                return new Cart();  // Return an empty cart if no items
            }

            return cart;  // Return the full cart object
        }
        // GET api/<ShoppingCartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var cart = GetCartFromSession();

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
        public void Post([FromBody] Product product)
        {
            Items item = new Items();
            item.Price = product.Price;

            if ( item.Quantity <= 0 || item.Price <= 0)
            {
                return; // Invalid item data, do nothing.
            }

            var cart = GetCartFromSession() ?? new Cart();

            // Check if the item already exists in the cart
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

            SetCartInSession(cart);
        }

        // PUT api/<ShoppingCartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] int quantity)
        {
            if (quantity <= 0)
            {
                return; // Invalid quantity, do nothing.
            }

            var cart = GetCartFromSession();

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
            existingItem.Quantity = quantity;
            SetCartInSession(cart);
        }

        // DELETE api/<ShoppingCartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cart = GetCartFromSession();

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
            SetCartInSession(cart);
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
            var cart = GetCartFromSession();
            if (cart == null || !cart.Items.Any())
            {
                return 0; // If no items, return 0 count.
            }

            return cart.Items.Sum(item => item.Quantity);
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
