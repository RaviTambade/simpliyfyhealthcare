using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TryWebAppMVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        [Route("products/{category}/{id}")]
        public ActionResult Details(string category,int id)
        {


            return View();
        }
    }
}