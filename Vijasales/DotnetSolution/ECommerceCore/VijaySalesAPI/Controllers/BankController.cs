using Microsoft.AspNetCore.Mvc;

namespace VijaySalesAPI.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
