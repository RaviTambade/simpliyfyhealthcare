using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDFCBankApp.Models;

namespace HDFCBankApp.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> list = new List<Customer>();

        public CustomersController() {
            list.Add(new Customer { Id = 1, Name = "Microsoft India", Email = "bill.gates@ms.com", Location = "Hydrabad" });
            list.Add(new Customer { Id = 2, Name = "IBM India", Email = "jhon.gates@ms.com", Location = "Mumbai" });
            list.Add(new Customer { Id = 3, Name = "Persisten India", Email = "bill.walter@ms.com", Location = "Pune" });
        }
        // GET: Customers
        public ActionResult Index()
        {
            ViewData["list"]=list;
            return View();
        }

        public ActionResult Details(int id)
        {
            //lambda experssion  (arrow function)
            Customer customer = list.Find(cust => cust.Id == id);
            return View(customer);
        }
    }
}