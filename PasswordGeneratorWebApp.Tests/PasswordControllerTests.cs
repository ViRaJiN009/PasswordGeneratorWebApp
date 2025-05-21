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
            var result = _controller.GeneratePassword(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var password = Assert.IsType<string>(okResult.Value);
            Assert.False(string.IsNullOrEmpty(password));
            Assert.Equal(12, password.Length);
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
            var result = _controller.GeneratePassword(model);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Invalid password length.", badRequestResult.Value);
        }

        [Fact]
        public void GeneratePassword_ValidRequest_ReturnsOkResultWithPassword()
        {
            // Arrange
            var controller = new PasswordController();
            var model = new PasswordModel
            {
                Length = 12,
                IncludeUppercase = true,
                IncludeNumbers = true,
                IncludeSpecialCharacters = true
            };

            // Act
            var result = controller.GeneratePassword(model);
            var okResult = Assert.IsType<ActionResult<string>>(result);
            string password = okResult.Value;

            // Assert
            Assert.False(string.IsNullOrEmpty(password));
        }
    }
}