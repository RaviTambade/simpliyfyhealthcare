using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace VijaySales.Tests.APITests
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Location { get; set; }
    }

    public class CustomersWebAPICURDTests
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "http://localhost:5222/api/customers";
        private readonly HttpClient _httpClient;

        public CustomersWebAPICURDTests()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public async Task Can_Create_Customer()
        {
            // Arrange
            var customer = new Customer { Id = 1, Email = "shiv.narayan@transflower.in", ContactNumber = "9881735801", Location = "Pune" };

            // Act
            var response = await _httpClient.PostAsync(BaseUrl,
                                                        new StringContent(JsonConvert.SerializeObject(customer),
                                                        Encoding.UTF8,
                                                        "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Can_Get_Customer()
        {
            // Act
            var response = await _httpClient.GetAsync(BaseUrl);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Can_Update_Customer()
        {
            // Arrange
            var customer = new Customer { Id = 1, Email = "rahul.navale@transflower.in", ContactNumber = "9881735802", Location = "Mumbai" };
            // Act
            var response = await _httpClient.PutAsync($"{BaseUrl}/{customer.Id}",
                                                       new StringContent(JsonConvert.SerializeObject(customer),
                                                       Encoding.UTF8,
                                                       "application/json"));
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Can_Delete_Customer()
        {
            // Arrange
            var customerId = 1;

            // Act
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{customerId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}