using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorWebApp.Controllers;
using PasswordGeneratorWebApp.Models;
using Xunit;

namespace PasswordGeneratorWebApp.Tests
{
    public class PasswordControllerTests
    {
        [Fact]
        public void GeneratePassword_ValidModel_ReturnsGeneratedPassword()
        {
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

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData["Error"]);
            Assert.NotNull(viewResult.ViewData["GeneratedPassword"] ?? controller.ViewBag.GeneratedPassword);
            var password = controller.ViewBag.GeneratedPassword as string;
            Assert.False(string.IsNullOrEmpty(password));
            Assert.Equal(12, password.Length);
        }

        [Fact]
        public void GeneratePassword_InvalidModel_ReturnsErrorView()
        {
            var controller = new PasswordController();
            var model = new PasswordModel
            {
                Length = 0,
                IncludeUppercase = true,
                IncludeNumbers = true,
                IncludeSpecialCharacters = true
            };

            // Act
            var result = controller.GeneratePassword(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Invalid password length.", controller.ViewBag.Error);
            Assert.Null(controller.ViewBag.GeneratedPassword);
        }
    }
}