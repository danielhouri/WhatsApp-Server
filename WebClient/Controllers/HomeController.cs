using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return File("index.html", "text/html");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}