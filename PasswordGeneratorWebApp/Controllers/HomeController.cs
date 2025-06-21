using Microsoft.AspNetCore.Mvc;

namespace PasswordGeneratorWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}