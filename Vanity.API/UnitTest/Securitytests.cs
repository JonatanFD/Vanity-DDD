using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Vanity.API.Security.Interface.REST;
using Vanity.API.Security.Interface.REST.Resource;
using Xunit;

namespace Vanity.API.Tests.UnitTests
{
    public class SecurityTests
    {
        [Fact]
        public void UpdateConfig_ExistingMonitor_ShouldReturnOkResult()
        {
            // Arrange
            var mockSecurityResource = new Vanity.API.Security.Interface.REST.Resource.SecurityResource(1234, 100);
            var mockStats = new List<Vanity.API.Security.Interface.REST.Resource.SecurityResource> { mockSecurityResource };

            var controller = new Vanity.API.Security.Interface.REST.Security
            {
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.UpdateConfig(mockSecurityResource);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void CreateMonitor_NewMonitor_ShouldReturnOkResult()
        {
            // Arrange
            var newSecurityResource = new Vanity.API.Security.Interface.REST.Resource.SecurityResource(5678, 200);
            var mockStats = new List<Vanity.API.Security.Interface.REST.Resource.SecurityResource>();

            var controller = new Vanity.API.Security.Interface.REST.Security
            {
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.CreateMonitor(newSecurityResource);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetMonitorById_ExistingMonitor_ShouldReturnOkResult()
        {
            // Arrange
            var mockStats = new List<Vanity.API.Security.Interface.REST.Resource.SecurityResource> { new Vanity.API.Security.Interface.REST.Resource.SecurityResource(1234, 100) };
            var id = 1234;

            var controller = new Vanity.API.Security.Interface.REST.Security
            {
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.GetMonitorById(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(mockStats[0], okResult.Value);
        }

        [Fact]
        public void GetMonitorById_NonExistingMonitor_ShouldReturnNotFoundResult()
        {
            // Arrange
            var mockStats = new List<Vanity.API.Security.Interface.REST.Resource.SecurityResource> { new Vanity.API.Security.Interface.REST.Resource.SecurityResource(1234, 100) };
            var id = 5678;

            var controller = new Vanity.API.Security.Interface.REST.Security
            {
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.GetMonitorById(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
