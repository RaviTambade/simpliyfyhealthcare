using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceEntities;

namespace ECommerceWeb.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            CustomerProfile theProfile = new CustomerProfile();
            theProfile.TheCustomer = new Customer
            {
                Id = 12,
                FirstName = "Raj",
                LastName = "Mane",
                Contact = "9883478569",
                Email = "raj.mane@gmail.com"
            };
            theProfile.OrderHistory  = new List<Order>();
            theProfile.OrderHistory.Add(new Order { Id = 12, Status = "delivered", Created = DateTime.Now, Amount = 76000 });
            theProfile.OrderHistory.Add(new Order { Id = 16, Status = "cancelled", Created = DateTime.Now, Amount = 34000 });
            ViewData["profile"] = theProfile;
            return View();
        }
    }
}