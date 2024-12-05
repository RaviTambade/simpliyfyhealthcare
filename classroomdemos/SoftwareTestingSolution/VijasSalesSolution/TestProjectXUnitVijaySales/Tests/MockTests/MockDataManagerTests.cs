using DataLib;
using Moq;
using Xunit;

public class DataManagerTests
{
    [Fact]
    public void GetDataFromRepository_ReturnsData()
    {
        // Arrange
        var mockRepository = new Mock<IRepository>();
        mockRepository.Setup(repo => repo.GetData()).Returns("Mocked data");

        var dataManager = new DataManager(mockRepository.Object);

        // Act
        var result = dataManager.GetDataFromRepository();

        // Assert
        Assert.Equal("Mocked data", result);
    }
}


/*
Mocking is useful for isolating the code under test and 
making unit tests more focused and deterministic. 
It allows you to simulate different scenarios and behaviors of dependencies 
without actually needing to implement them fully.
 */