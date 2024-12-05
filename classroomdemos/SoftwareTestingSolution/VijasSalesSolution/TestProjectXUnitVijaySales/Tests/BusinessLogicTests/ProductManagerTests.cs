using MathLib;
using ProductCatalog.Entities;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VijaySales.Tests.BusinessLogicTests
{
    public class ProductManagerTests
    {
        [Fact]
        public void GetAllProductsByProductManagerTest()
        {
            //Arrange

            List<Product> expectedProducts = new List<Product>();
            expectedProducts.Add(new Product { Name = "Jasmine", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
            expectedProducts.Add(new Product { Name = "Rose", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
            expectedProducts.Add(new Product { Name = "Tulip", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
            expectedProducts.Add(new Product { Name = "Lotus", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
            expectedProducts.Add(new Product { Name = "Marigold", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });



            //Act
            List<Product> actualProducts = ProductManager.GetAll();

            //Assert
            Assert.Equal(expectedProducts, actualProducts);
        }

    }
}
