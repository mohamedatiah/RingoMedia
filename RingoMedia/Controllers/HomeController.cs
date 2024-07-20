using Microsoft.AspNetCore.Mvc;

namespace RingoMedia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
