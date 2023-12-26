using Microsoft.AspNetCore.Mvc;

namespace SPA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Err()
        {
            return View();
        }
    }
}
