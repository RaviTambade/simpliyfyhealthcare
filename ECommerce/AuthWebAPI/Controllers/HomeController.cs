using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace AuthWebAPI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult GetUser()
        {
            ViewBag.Title = "Home Page";
            var result = new
            {
                Id = 12,
                FirstName = "Raj",
                LastName = "Nene"
            };
            return   Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            string result = "Invalid User";
            if(email=="ravi.tambade@gmail.com" && password == "123")
            {
                result = "Valid User"

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}