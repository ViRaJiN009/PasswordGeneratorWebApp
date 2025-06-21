using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorWebApp.Controllers;
using Xunit;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PasswordGeneratorWebApp.Tests
{
    public class PasswordControllerTests
    {
        [Fact]
        public void GeneratePassword_ReturnsPasswordOfCorrectLength()
        {
            var controller = new PasswordController();
            var result = controller.GeneratePassword(16, true, true, true, true) as JsonResult;
            var data = result.Value as IDictionary<string, string>;

            Assert.NotNull(data);
            Assert.NotNull(data["password"]);
            Assert.Equal(16, data["password"].Length);
            Assert.True(string.IsNullOrEmpty(data["error"]));
        }

        [Fact]
        public void GeneratePassword_ReturnsErrorWhenNoCharacterTypesSelected()
        {
            var controller = new PasswordController();
            var result = controller.GeneratePassword(12, false, false, false, false) as JsonResult;
            var data = result.Value as IDictionary<string, string>;

            Assert.NotNull(data);
            Assert.Equal("", data["password"]);
            Assert.Equal("Please select at least one character type", data["error"]);
        }

        [Fact]
        public void GeneratePassword_OnlyUppercase()
        {
            var controller = new PasswordController();
            var result = controller.GeneratePassword(10, true, false, false, false) as JsonResult;
            var data = result.Value as IDictionary<string, string>;

            Assert.NotNull(data);
            Assert.Matches(new Regex("^[A-Z]{10}$"), data["password"]);
            Assert.True(string.IsNullOrEmpty(data["error"]));
        }

        [Fact]
        public void GeneratePassword_OnlyLowercase()
        {
            var controller = new PasswordController();
            var result = controller.GeneratePassword(10, false, true, false, false) as JsonResult;
            var data = result.Value as IDictionary<string, string>;

            Assert.NotNull(data);
            Assert.Matches(new Regex("^[a-z]{10}$"), data["password"]);
            Assert.True(string.IsNullOrEmpty(data["error"]));
        }

        [Fact]
        public void GeneratePassword_OnlyNumbers()
        {
            var controller = new PasswordController();
            var result = controller.GeneratePassword(8, false, false, true, false) as JsonResult;
            var data = result.Value as IDictionary<string, string>;

            Assert.NotNull(data);
            Assert.Matches(new Regex("^[0-9]{8}$"), data["password"]);
            Assert.True(string.IsNullOrEmpty(data["error"]));
        }

        [Fact]
        public void GeneratePassword_OnlySymbols()
        {
            var controller = new PasswordController();
            var result = controller.GeneratePassword(6, false, false, false, true) as JsonResult;
            var data = result.Value as IDictionary<string, string>;

            Assert.NotNull(data);
            Assert.Matches(new Regex("^[!@#$%^&*()\\-_=+\\[\\]{}|;:,.<>?]{6}$"), data["password"]);
            Assert.True(string.IsNullOrEmpty(data["error"]));
        }

        [Fact]
        public void GeneratePassword_AllTypes()
        {
            var controller = new PasswordController();
            var result = controller.GeneratePassword(20, true, true, true, true) as JsonResult;
            var data = result.Value as IDictionary<string, string>;

            string password = data["password"];
            Assert.NotNull(password);
            Assert.Equal(20, password.Length);
            Assert.Contains(password, c => char.IsUpper(c));
            Assert.Contains(password, c => char.IsLower(c));
            Assert.Contains(password, c => char.IsDigit(c));
            Assert.Contains(password, c => "!@#$%^&*()-_=+[]{}|;:,.<>?".Contains(c));
            Assert.True(string.IsNullOrEmpty(data["error"]));
        }
    }
}