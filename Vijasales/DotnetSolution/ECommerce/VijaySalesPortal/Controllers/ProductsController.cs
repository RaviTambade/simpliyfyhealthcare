using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VijaySalesPortal.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        public ActionResult Management()
        {
            return View();
        }
    }
}