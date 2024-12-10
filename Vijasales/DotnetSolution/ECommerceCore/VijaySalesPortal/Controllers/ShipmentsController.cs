using Microsoft.AspNetCore.Mvc;

namespace VijaySalesPortal.Controllers
{
    public class ShipmentsController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Details(int id)
        {

            return View();
        }

    }
}
