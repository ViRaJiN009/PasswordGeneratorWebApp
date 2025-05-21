using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorWebApp.Models;

namespace PasswordGeneratorWebApp.Controllers
{
    public class PasswordController : Controller
    {
        [HttpPost]
        public IActionResult GeneratePassword(PasswordModel model)
        {
            if (model.Length <= 0)
            {
                ViewBag.GeneratedPassword = null;
                ViewBag.Error = "Invalid password length.";
                return View("~/Views/Home/Index.cshtml");
            }

            var chars = "abcdefghijklmnopqrstuvwxyz";
            if (model.IncludeUppercase) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (model.IncludeNumbers) chars += "0123456789";
            if (model.IncludeSpecialCharacters) chars += "!@#$%^&*";

            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, model.Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            ViewBag.GeneratedPassword = password;
            ViewBag.Error = null;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}


