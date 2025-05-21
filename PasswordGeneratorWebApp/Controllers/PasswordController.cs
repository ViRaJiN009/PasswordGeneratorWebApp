using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorWebApp.Models;

namespace PasswordGeneratorWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        [HttpPost("generate")]
        public ActionResult<string> GeneratePassword([FromBody] PasswordModel model)
        {
            if (model.Length < 1)
            {
                return BadRequest("Password length must be at least 1.");
            }

            var password = GenerateRandomPassword(model.Length, model.IncludeUppercase, model.IncludeNumbers, model.IncludeSpecialCharacters);
            return Ok(password);
        }

        private string GenerateRandomPassword(int length, bool includeUppercase, bool includeNumbers, bool includeSpecialCharacters)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string specialCharacters = "!@#$%^&*()_-+=<>?";

            string characterSet = lowercase;

            if (includeUppercase)
            {
                characterSet += uppercase;
            }
            if (includeNumbers)
            {
                characterSet += numbers;
            }
            if (includeSpecialCharacters)
            {
                characterSet += specialCharacters;
            }

            var random = new Random();
            char[] password = new char[length];

            for (int i = 0; i < length; i++)
            {
                password[i] = characterSet[random.Next(characterSet.Length)];
            }

            return new string(password);
        }
    }
}