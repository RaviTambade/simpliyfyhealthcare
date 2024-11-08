using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using POCO;
using Specification;
using Services;

namespace ECommerceWeb.Controllers
{
    public class ProductsController : Controller
    {


        //should contain action methods

        // GET: Products
        public ActionResult Index()
        {
            IProductService svc = new ProductService();
            ProductService pSvc = (ProductService)svc;
            pSvc.Seeding();
            List<Product> products =svc.GetAll();
            return View(products);
        }

        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Insert() { 
             return View();
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}