using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Net.Http.Headers;

namespace VijaySales.Tests.APITests
{
    public class SecureOrdersAPITests
    {
        private readonly HttpClient _client;

        public SecureOrdersAPITests()
        {
            // Initialize HttpClient with the base address of your web API
            _client = new HttpClient { BaseAddress = new Uri("http://localhost:5295/") };
        }

        [Fact]
        public async Task Get_Orders_ReturnsSuccessStatusForAbhayUser()
        {
            // Arrange
            //This token is for user Abhay

            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjb250YWN0TnVtYmVyIjoiODQ1NjEyMzY1NCIsIm5hbWVpZCI6IjEiLCJ1bmlxdWVfbmFtZSI6IkFiaGF5TmF2YWxlIiwicm9sZSI6IkRpcmVjdG9yIiwibmJmIjoxNzEzNjA4OTYzLCJleHAiOjE3MTM2OTUzNjMsImlhdCI6MTcxMzYwODk2M30.j3dqfokzlue0z1nK-C7j4Zahvfj1Siov_ru02XB3yO0";
            //string token = "invalid token";
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act

            var response = await _client.GetAsync("api/orders");

            // Assert

            response.EnsureSuccessStatusCode(); // Throws exception if status code isn't success
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task Get_Orders_ReturnsSuccessStatusForPragatiUser()
        {
            // Arrange
            //This token is for user Pragati
            //Invoke agent classes for setting token
            //Invoke agen classes for getting sample data
            //Invoke agent classes for preparing unit test case exeuction

            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjb250YWN0TnVtYmVyIjoiODQ1NjEyMzY1NCIsIm5hbWVpZCI6IjEiLCJ1bmlxdWVfbmFtZSI6IkFiaGF5TmF2YWxlIiwicm9sZSI6IkRpcmVjdG9yIiwibmJmIjoxNzEzNzgyNDIwLCJleHAiOjE3MTM4Njg4MjAsImlhdCI6MTcxMzc4MjQyMH0.AwnYobXzxRE-b8MpzgXbn2X1U2ASbTN9Knvx1BMudcU";
            //string token = "invalid token";
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("api/orders");

            // Assert
            response.EnsureSuccessStatusCode(); // Throws exception if status code isn't success
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
}
}