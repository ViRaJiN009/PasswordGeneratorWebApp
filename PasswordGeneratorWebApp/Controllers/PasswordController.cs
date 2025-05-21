using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorWebApp.Models;

namespace PasswordGeneratorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> GeneratePassword([FromBody] PasswordModel model)
        {
            if (model.Length <= 0)
                return BadRequest("Invalid password length.");

            // Simple password generation logic for demo
            var chars = "abcdefghijklmnopqrstuvwxyz";
            if (model.IncludeUppercase) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (model.IncludeNumbers) chars += "0123456789";
            if (model.IncludeSpecialCharacters) chars += "!@#$%^&*";

            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, model.Length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var okResult = Assert.IsType<ActionResult<string>>(result);
            string password = okResult.Value;

            return Ok(password);
        }
    }
}