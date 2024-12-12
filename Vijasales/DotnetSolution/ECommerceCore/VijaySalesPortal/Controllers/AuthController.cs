using Microsoft.AspNetCore.Mvc;

namespace VijaySalesPortal.Controllers
{
    public class AuthController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public AuthController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
