using Microsoft.AspNetCore.Mvc;

namespace EcoSip.Web.Controllers
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
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Conoce más sobre EcoSip";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Ponte en contacto con nosotros";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}