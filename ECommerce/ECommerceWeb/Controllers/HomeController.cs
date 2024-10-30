using ECommerceWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWeb.Controllers
{
    public class HomeController : Controller
    {

        //action methods
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 2000, Image="/Images/gerbera.jpg" });
            products.Add(new Product { Id = 2, Name = "rose", Description = "Valentine Flower", UnitPrice = 23, Quantity = 9000 ,Image = "/images/rose.jpg" });
            products.Add(new Product { Id = 3, Name = "lily", Description = "Delicate Flower", UnitPrice = 2, Quantity = 7000 , Image = "/images/lily.jpg" });
            products.Add(new Product { Id = 4, Name = "jasmine", Description = "Fregrance Flower", UnitPrice = 12, Quantity = 55000 , Image = "/images/jasmines.jpg" });
            products.Add(new Product { Id = 5, Name = "lotus", Description = "Worship Flower", UnitPrice = 45, Quantity = 15000, Image = "/images/lotus.jpg" });
           
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}