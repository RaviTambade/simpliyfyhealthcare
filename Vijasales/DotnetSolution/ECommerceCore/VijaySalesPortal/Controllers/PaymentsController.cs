using Microsoft.AspNetCore.Mvc;

namespace VijaySalesPortal.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult PayNow()
        {
            return View();
        }
        

    }
}
