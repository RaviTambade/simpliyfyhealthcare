using Microsoft.AspNetCore.Mvc;
using ProductCatalogueTest.Models;

namespace ProductCatalogueTest.Controllers
{
    public class Products : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GridLayout()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Grid()
        {
            var cardList = new List<CardModel>
        {
            new CardModel { ImageUrl = "/Images/galaxy_M05.jpg", Title = "Galaxy M05 - View 1",Price=10000 },
            new CardModel { ImageUrl = "/Images/galaxy_S22.jpg", Title = "Galaxy S22 - View 1",Price=50000 },
            new CardModel { ImageUrl = "/Images/galaxy_S23.jpg", Title = "Galaxy S23 - View 1",Price=55000 },
            new CardModel { ImageUrl = "/Images/galaxy_M05.jpg", Title = "Galaxy M05 - View 1",Price=10000 },
            new CardModel { ImageUrl = "/Images/galaxy_S22.jpg", Title = "Galaxy S22 - View 1",Price=50000 },
            new CardModel { ImageUrl = "/Images/galaxy_S23.jpg", Title = "Galaxy S23 - View 1",Price=55000 },


            };


            return Json(cardList);
        }
    }
}
