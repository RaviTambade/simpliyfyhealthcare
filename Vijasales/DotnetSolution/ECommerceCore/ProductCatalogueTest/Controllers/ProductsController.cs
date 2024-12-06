using Microsoft.AspNetCore.Mvc;
using ProductCatalogueTest.Models;


namespace ProductCatalogueTest.Controllers
{
    public class ProductsController : Controller
    {

        private static readonly List<CardModel> cardList = new List<CardModel>
        {
            new CardModel { Id = 1, ImageUrl = "/Images/galaxy_M05.jpg", Title = "Galaxy M05", Price = 10000, Description = "This is Galaxy M05 with great features", Stock = 10 },
            new CardModel { Id = 2, ImageUrl = "/Images/galaxy_S22.jpg", Title = "Galaxy S22", Price = 50000, Description = "Galaxy S22 with top notch performance", Stock = 5 },
            new CardModel { Id = 3, ImageUrl = "/Images/galaxy_S23.jpg", Title = "Galaxy S23", Price = 55000, Description = "Galaxy S23 with the latest technology", Stock = 8 },
            new CardModel { Id = 4, ImageUrl = "/Images/galaxy_M05.jpg", Title = "Galaxy M05", Price = 10000, Description = "This is Galaxy M05 with great features", Stock = 10 },
            new CardModel { Id = 5, ImageUrl = "/Images/galaxy_S22.jpg", Title = "Galaxy S22", Price = 50000, Description = "Galaxy S22 with top notch performance", Stock = 5 },
            new CardModel { Id = 6, ImageUrl = "/Images/galaxy_S23.jpg", Title = "Galaxy S23", Price = 55000, Description = "Galaxy S23 with the latest technology", Stock = 8 }
        };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductIndex()
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

            return Json(cardList);
        }

        public IActionResult CardLayout()
        {
            return View();
        }


        public IActionResult Details(int id)
        {
            var product = cardList.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
