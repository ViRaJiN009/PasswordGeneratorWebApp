using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

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

            string password = GenerateAdvancedPassword(length, useUppercase, useLowercase, useNumbers, useSymbols);

            result["password"] = password;
            result["error"] = "";
            return Json(result);
        }

        // Advanced password generator: ensures at least one of each selected type, shuffles, and uses cryptographic RNG
        private string GenerateAdvancedPassword(int length, bool useUppercase, bool useLowercase, bool useNumbers, bool useSymbols)
        {
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const string symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            var charSets = new List<string>();
            if (useUppercase) charSets.Add(uppercase);
            if (useLowercase) charSets.Add(lowercase);
            if (useNumbers) charSets.Add(numbers);
            if (useSymbols) charSets.Add(symbols);

            var allChars = string.Concat(charSets);

            // Ensure at least one character from each selected set
            var passwordChars = new List<char>();
            foreach (var set in charSets)
            {
                passwordChars.Add(set[GetRandomInt(set.Length)]);
            }

            // Fill the rest of the password
            for (int i = passwordChars.Count; i < length; i++)
            {
                passwordChars.Add(allChars[GetRandomInt(allChars.Length)]);
            }

            // Shuffle the password to avoid predictable positions
            Shuffle(passwordChars);

            return new string(passwordChars.ToArray());
        }

        // Cryptographically secure random integer
        private int GetRandomInt(int max)
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[4];
            int value;
            do
            {
                rng.GetBytes(bytes);
                value = BitConverter.ToInt32(bytes, 0) & int.MaxValue;
            } while (value >= max * (int.MaxValue / max));
            return value % max;
        }

        // Fisher-Yates shuffle
        private void Shuffle(List<char> list)
        {
            using var rng = RandomNumberGenerator.Create();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[4];
                rng.GetBytes(box);
                int k = (BitConverter.ToInt32(box, 0) & int.MaxValue) % n;
                n--;
                (list[n], list[k]) = (list[k], list[n]);
            }
        }
    }
}


