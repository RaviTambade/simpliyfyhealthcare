using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogueTest.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCartController1
        public ActionResult GetCart()
        {
            return View();
        }

       
    }
}
