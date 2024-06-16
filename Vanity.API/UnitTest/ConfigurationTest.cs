using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vanity.API.Configuration.Interface.REST;
using Vanity.API.Configuration.Interface.REST.Resource;
using Xunit;

namespace Vanity.API.Tests.UnitTests
{
    public class ConfigurationControllerTests
    {
        [Fact]
        public void UpdateConfig_ExistingConfig_ShouldReturnOkResult()
        {
            // Arrange
            var mockConfigResource = new Vanity.API.Configuration.Interface.REST.Resource.ConfigurationResource(1234, "WireGuard");
            var mockConfigs = new List<Vanity.API.Configuration.Interface.REST.Resource.ConfigurationResource> { mockConfigResource };

            var controller = new Vanity.API.Configuration.Interface.REST.ConfigurationController
            {
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.UpdateConfig(mockConfigResource);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void CreateConfig_NewConfig_ShouldReturnOkResult()
        {
            // Arrange
            var newConfigResource = new Vanity.API.Configuration.Interface.REST.Resource.ConfigurationResource(5678, "OpenVPN");
            var mockConfigs = new List<Vanity.API.Configuration.Interface.REST.Resource.ConfigurationResource>();

            var controller = new Vanity.API.Configuration.Interface.REST.ConfigurationController
            {
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.CreateConfig(newConfigResource);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetConfigById_ExistingConfig_ShouldReturnOkResult()
        {
            // Arrange
            var mockConfigs = new List<Vanity.API.Configuration.Interface.REST.Resource.ConfigurationResource> { new Vanity.API.Configuration.Interface.REST.Resource.ConfigurationResource(1234, "WireGuard") };
            var id = 1234;

            var controller = new Vanity.API.Configuration.Interface.REST.ConfigurationController
            {
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.GetConfigById(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(mockConfigs[0], okResult.Value);
        }

        [Fact]
        public void GetConfigById_NonExistingConfig_ShouldReturnNotFoundResult()
        {
            // Arrange
            var mockConfigs = new List<Vanity.API.Configuration.Interface.REST.Resource.ConfigurationResource> { new Vanity.API.Configuration.Interface.REST.Resource.ConfigurationResource(1234, "WireGuard") };
            var id = 5678;

            var controller = new Vanity.API.Configuration.Interface.REST.ConfigurationController
            {
                ControllerContext = new ControllerContext()
            };
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = controller.GetConfigById(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
