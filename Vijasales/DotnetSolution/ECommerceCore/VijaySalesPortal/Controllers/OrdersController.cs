﻿using Microsoft.AspNetCore.Mvc;

namespace VijaySalesPortal.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult OrderDetails() 
        {
            return View();
        }

        public IActionResult SalesOrderDetails()
        {
            return View();
        }
    }
}
