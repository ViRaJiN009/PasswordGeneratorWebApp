using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace PasswordGeneratorWebApp.Controllers
{
    public class PasswordController : Controller
    {
        [HttpGet]
        public IActionResult GeneratePassword(
            int length = 12,
            bool useUppercase = true,
            bool useLowercase = true,
            bool useNumbers = true,
            bool useSymbols = false)
        {
            var result = new Dictionary<string, string>();

            if (!(useUppercase || useLowercase || useNumbers || useSymbols))
            {
                result["password"] = "";
                result["error"] = "Please select at least one character type";
                return Json(result);
            }

            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const string symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            var charSet = new StringBuilder();
            if (useUppercase) charSet.Append(uppercase);
            if (useLowercase) charSet.Append(lowercase);
            if (useNumbers) charSet.Append(numbers);
            if (useSymbols) charSet.Append(symbols);

            var chars = charSet.ToString();
            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            result["password"] = password;
            result["error"] = "";
            return Json(result);
        }
    }
}


