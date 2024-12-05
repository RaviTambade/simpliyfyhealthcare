using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Text.Json;

using System.Text;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using ProductCatalog.Entities;
using HR.Entities;

namespace VijaySales.Tests.APITests
{

    public class ProductsAPITests 
        {    
            private const string BaseUrl = "http://localhost:5222/products";
            private readonly HttpClient _httpClient;

            public ProductsAPITests()
            {
                _httpClient = new HttpClient();
            }


            [Fact]
            public async Task Get_ReturnsCorrectResponse()
            {
                // Arrange
                List<Product> expectedProducts = new List<Product>();
                expectedProducts.Add(new Product { Name = "Jasmine", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
                expectedProducts.Add(new Product { Name = "Jaae", Description = "Smelling Flower", Category = "flowers", StockAvailable = 78, UnitPrice = 12 });
                expectedProducts.Add(new Product { Name = "Tulip", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
                expectedProducts.Add(new Product { Name = "Lotus", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
                expectedProducts.Add(new Product { Name = "Marigold", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });


                // Act
                var response = await _httpClient.GetAsync(BaseUrl);
                response.EnsureSuccessStatusCode();

                var content=await response.Content.ReadAsStringAsync();
                List<Product> resultProducts = JsonSerializer.Deserialize<List<Product>>(content);
                Assert.Equal(expectedProducts, resultProducts);
            }
        }
    }