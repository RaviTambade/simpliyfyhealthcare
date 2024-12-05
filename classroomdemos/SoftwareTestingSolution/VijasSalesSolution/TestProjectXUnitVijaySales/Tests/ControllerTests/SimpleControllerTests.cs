using MathLib;
using ShoppingCartAPI.Controllers;


namespace VijaySales.Tests.ControllerTests
{
    public class SimpleControllerTests
    {
        [Fact]
        public void GetReturnsCorrectValue()
        {
            //Arrange
            var controller = new SimpleController();
            int id = 56;

            string expectedValue = "simple";

            //Act
            var result = controller.Get(id);

            //Assert
            Assert.Equal(expectedValue, result.Value);
        }


    }
}