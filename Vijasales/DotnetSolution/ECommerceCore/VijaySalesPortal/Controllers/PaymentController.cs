using Microsoft.AspNetCore.Mvc;

namespace VijaySalesPortal.Controllers
{
    public class PaymentController : Controller
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
