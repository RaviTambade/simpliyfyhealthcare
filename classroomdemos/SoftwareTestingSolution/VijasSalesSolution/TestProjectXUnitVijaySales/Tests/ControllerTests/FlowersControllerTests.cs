using MathLib;
using CatalogAPI.Controllers;
using ProductCatalog.Entities;

namespace VijaySales.Tests.ControllerTests
{
    public class FlowersControllerTests
    {

        [Fact]
        public async Task GetAsync_GetProduct()
        {
            //Arrange
            var controller = new FlowersController();
            int id = 45;
             Product expectedProduct= new Product { Name = "Jasmine", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 };
             
            //Act
            var actualProduct = await controller.GetByIdAsync(id);

            //Assert
            Assert.Equal(expectedProduct, actualProduct);
        }
    }
}