using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.Entities;
using TestProjectXUnitVijaySales.Utility;

namespace VijaySales.Tests.ProductCatalogTests
{

    //Object Layer unit Test

    public class ProductEntityTests
    {
        [Fact]
        public static void SingleProductEntityTest()
        {
           /* Product product = new Product();
            product.Name = "Gerbera";
            product.Description = "Wedding Flower";
            product.Category = "flower";
            product.UnitPrice = 10;
            product.StockAvailable = 6000;

            Assert.NotNull(product);
            Assert.Equal(6000, product.StockAvailable);
           
            */
           // Assuming there are three products in the database
            //Assert.NotEmpty(product);  //It is used for collection  tests
        }
    }
}
