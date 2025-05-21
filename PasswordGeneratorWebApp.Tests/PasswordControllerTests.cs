using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorWebApp.Controllers;
using PasswordGeneratorWebApp.Models;
using Xunit;

namespace PasswordGeneratorWebApp.Tests
{
    public class PasswordControllerTests
    {
        private readonly PasswordController _controller;

        public PasswordControllerTests()
        {
            _controller = new PasswordController();
        }

        [Fact]
        public void GeneratePassword_ValidModel_ReturnsGeneratedPassword()
        {
            // Arrange
            var model = new PasswordModel
            {
                Length = 12,
                IncludeUppercase = true,
                IncludeNumbers = true,
                IncludeSpecialCharacters = true
            };

            // Act
            var result = _controller.GeneratePassword(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result.ViewData["GeneratedPassword"]);
            Assert.Equal(12, ((string)result.ViewData["GeneratedPassword"]).Length);
        }

        [Fact]
        public void GeneratePassword_InvalidModel_ReturnsErrorView()
        {
            // Arrange
            var model = new PasswordModel
            {
                Length = 0, // Invalid length
                IncludeUppercase = true,
                IncludeNumbers = true,
                IncludeSpecialCharacters = true
            };

            // Act
            var result = _controller.GeneratePassword(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Error", result.ViewName);
        }
    }
}