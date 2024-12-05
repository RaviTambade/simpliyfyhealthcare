using System.Net;


namespace VijaySales.Tests.APITests
{
    public class RemoteWebAPITests
    {

        private readonly HttpClient _client;

        public RemoteWebAPITests()
        {
            // Initialize HttpClient with the base address of your web API
            _client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/") };

        }

        [Fact]
        public async Task Get_ReturnsSuccessStatus()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("WeatherForecast");

            // Assert
            response.EnsureSuccessStatusCode(); // Throws exception if status code isn't success
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}