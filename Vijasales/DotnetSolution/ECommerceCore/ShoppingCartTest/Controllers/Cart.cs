﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartTest.Models;

namespace ShoppingCartTest.Controllers
{
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

    }
}
