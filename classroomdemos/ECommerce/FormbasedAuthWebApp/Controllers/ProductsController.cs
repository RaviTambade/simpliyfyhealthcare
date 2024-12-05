using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormbasedAuthWebApp.Controllers
{
    public class ProductsController : Controller
    {
        
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 60, VaryByParam = "id")]
        public ActionResult Product(int id)
        {
            var product = new
            {
                ProductId = id,
                Title = "Gerbera",
                UnitPrice = 4
            };
            return View(product);
        }

        public ActionResult List()
        {

            // Set cache expiration to 60 minutes
            Response.Cache.SetExpires(DateTime.Now.AddMinutes(60));
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetValidUntilExpires(true);

            return View();
        }


        [OutputCache(CacheProfile  = "CacheFor60Seconds")]
        public ActionResult Catalog()
        {
            return View();
        }
        

    }
}