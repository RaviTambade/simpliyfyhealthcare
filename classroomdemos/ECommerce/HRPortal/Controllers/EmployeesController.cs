using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using HRPortal.Models;

namespace HRPortal.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id) { 
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            string firstName = collection["firstname"] as string;
            string lastname = collection["firstname"] as string;
            string email = collection["firstname"] as string;
            string contactNumber = collection["firstname"] as string;

            return View();
        }



        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Employee emp)
        {


            return View();
        }




        public ActionResult Edit(int id)
        {
           Employee employee = new Employee();
            //get employee details based on id from json file
            employee.Id = id;
            employee.Name = "Rajiv Kapoor";
            employee.IsConfirmed = true;
            employee.DailyAllowance = 400;
            employee.BasicSalary = 14000;
            employee.WorkingDays = 20; ;
            employee.JoinDate = DateTime.Now;
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {



            return View();

        }
    }
}