using Xunit;
using MathLib;
using System.Collections.Generic;

//Business Logic Layer Test
//Sample Data Colletion for testing Sum Method of Calculator
namespace VijaySales.Tests.MathsTests
{
    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { -4, -6, -10 };
            yield return new object[] { -2, 2, 0 };
            yield return new object[] { int.MinValue, -1, int.MaxValue };
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class CalculatorTests
    {
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-2, 3, 1)]
        [InlineData(10, -5, 5)]
        [InlineData(6, 4, 10)]
        public void Add_ReturnsCorrectSum(int a, int b, int expectedSum)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Sum(a, b);

            // Assert
            Assert.Equal(expectedSum, result);
        }


        [Theory]
        [InlineData(2, 3, -1)]
        [InlineData(0, 0, 0)]
        [InlineData(-2, 3, -5)]
        [InlineData(10, -5, 15)]
        public void Add_ReturnsCorrectSubtract(int a, int b, int expectedSum)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Subtract(a, b);

            // Assert
            Assert.Equal(expectedSum, result);
        }


        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void CanAddTheorySampleData(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Sum(value1, value2);

            Assert.Equal(expected, result);
        }


        [Fact]
        public async void Get_ProcessRequestAsyncTest()
        {
            //Arrange
            var calculator = new Calculator();
            int expectedResult = 78;

            //Act
            int actualResult = await calculator.ProcessRequestAsync();

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}