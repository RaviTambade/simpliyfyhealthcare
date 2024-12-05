using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BannkingPortal.Controllers
{
    public class HomeController : Controller
    {
        //action methods
        public ActionResult Index()
        {
            string company = "Transflower Learning Pvt. Ltd";
            return View();
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