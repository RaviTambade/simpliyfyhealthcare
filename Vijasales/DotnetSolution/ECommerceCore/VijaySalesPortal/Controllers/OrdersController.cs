using Microsoft.AspNetCore.Mvc;

namespace VijaySalesPortal.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult OrderDetails(int Id) 
        {
            return View();
        }

        public IActionResult SalesOrderDetails()
        {
            return View();
        }

        //SalesViewDetails
        public IActionResult SalesViewDetails()
        {
            return View();
        }
    }
}
