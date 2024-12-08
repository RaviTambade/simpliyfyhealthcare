using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Results;
using System.Web.Management;
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
       
        [HttpPost]
        public ActionResult login(string email, string password)
        {
            string result = "Invalid User";
            if(email=="ravi.tambade@gmail.com" && password == "123")
            {
                result = "Valid User";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
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
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Storage()
        {

            return View();
        }

        public ActionResult JqueryDemo()
        {
            return View();
        }


        public ActionResult Register()
        {

            return View();
        }
        public ActionResult SignIn()
        {

            return View();
        }

        public ActionResult Gdi()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }


        public ActionResult Sort()
        {
            return View();
        }


        public ActionResult Options()
        {
            return View();
        }

        public ActionResult MultipleChecks()
        {
            return View();
        }

        public ActionResult StatesCities()
        {
            return View();
        }

        public ActionResult TeamSelection()
        {
            return View();
        }

        public ActionResult DataEntryPregress()
        {
            return View();
        }

        public ActionResult CreditCard()
        {
            return View();
        }

        public ActionResult SliderProgress()
        {
            return View();
        }


        public ActionResult ProductsGrid()
        {
            return View();
        }


        public ActionResult CardsGridSort()
        {
            return View();
        }

        public ActionResult Catalog()
        {
            return View();
        }

        public ActionResult CatalogAjax()
        {
            return View();
        }

        public ActionResult Promise()
        {
            return View();
        }
        public ActionResult OopsJS()
        {
            return View();
        }
    }
}