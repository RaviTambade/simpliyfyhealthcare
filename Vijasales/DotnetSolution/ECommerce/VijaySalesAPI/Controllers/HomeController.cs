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

        public ActionResult SalesOrderDetails()
        {
            ViewBag.Title = "Home Page";

            return View();
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
    }
    }

