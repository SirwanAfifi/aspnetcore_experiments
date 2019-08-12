using DependencyInjection.Controllers;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DependencyInjection.Tests
{
    public class DITest
    {
        [Fact]
        public void ControllerTest()
        {
            // Arrange
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.Products).Returns(data);
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Index();

            // Assert
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}