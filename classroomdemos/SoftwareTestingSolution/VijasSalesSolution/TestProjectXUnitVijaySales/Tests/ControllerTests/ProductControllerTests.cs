using MathLib;
using CatalogAPI.Controllers;
using ProductCatalog.Entities;

namespace VijaySales.Tests.ControllerTests
{
    public class ProductControllerTests
    {
        [Fact]
        public void GetProduct()
        {
          /*  //Arrange
            var controller = new ProductsController();

            //Sample Data 
            Product expectedProduct = new Product("Rose", "Smelling Flower", "flowers", 4500, 12);
            int id = 45;

            //Act
            var actualProduct = controller.GetById(45);

            //Assert
            Assert.Equal(expectedProduct, actualProduct);

            */

        }

        [Fact]
        public void GetProducts()
        {
           /* //Arrange
            var controller = new ProductsController();


            //Sample Data 
            List<Product> expectedProducts = new List<Product>();
            expectedProducts.Add(new Product("Jasmine", "Smelling Flower", "flowers", 4500, 12));
            expectedProducts.Add(new Product("Tulip", "Delicate Flower", "flowers", 5400, 10));
            expectedProducts.Add(new Product("Marigold", "Festival Flower", "flowers", 45000, 1));
            expectedProducts.Add(new Product("Lotus", "Worship Flower", "flowers", 3400, 24));
            //Act
            var actualProducts = controller.GetAll();


            //Assert
            Assert.Equal(expectedProducts, actualProducts);*/

        }

        [Fact]
        public async Task GetAsync_GetFlower()
        {
            //Arrange
            var controller = new FlowersController();
            int id = 45;
            Product expectedProduct = new Product { Name = "Jasmine", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 };


            //Act
            var actualProduct = await controller.GetByIdAsync(id);

            //Assert
            Assert.Equal(expectedProduct, actualProduct);
        }
    }
}