using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VijaySalesPortalSOA.Controllers
{
    public class ShipmentsController : Controller
    {
        // GET shipments/list
        public ActionResult List()
        {
            return View();
        }

        // GET shipments/details/id
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}