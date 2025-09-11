using Microsoft.AspNetCore.Mvc;

namespace EcoSip.Web.Controllers
{
    public class LoginController : Controller
    {
         public IActionResult Index()
        {
            return View();
        }
    }
}
