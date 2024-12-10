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
using VijaySalesSOA.Filters;
using Catalog.Entities;
using Newtonsoft.Json;

namespace VijaySalesSOA.Controllers
{
    //[SessionState]  // Custom filter to enable session in Web API controller
    public class ShoppingCartController : ApiController
    {
        [HttpGet]
        public Cart Get()
        {
            // Access session safely
            Items items = new Items();
            items.Quantity = 1;
            items.ProductId = 1;
            items.Price = 12;

            Cart cart = new Cart();
            cart.Items.Add(items);
            var cookie = HttpContext.Current.Request.Cookies["cartData"];
            if (cookie == null)
            {
                return cart;
            }

            var cartItems = JsonConvert.DeserializeObject<Cart>(cookie.Value);
            return cart;  // Return the full cart object

        }

        [HttpPost]
        //[SessionState]
        public IHttpActionResult Post([FromBody] Product product)

        {
            Items items = new Items();
            items.Quantity = 1;
            items.ProductId = product.Id;
            items.Price=product.Price;
            
            Cart cart=new Cart();
            cart.Items.Add(items);
                var cartData = JsonConvert.SerializeObject(cart);
            var cookie = new HttpCookie("cartData", cartData)
            {
                Expires = DateTime.Now.AddMinutes(30) // Set cookie expiration
                                                      }; 
             HttpContext.Current.Response.Cookies.Add(cookie);
             return Ok("items added");
            }

        }

}