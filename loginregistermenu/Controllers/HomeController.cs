using Microsoft.AspNetCore.Mvc;

namespace loginregistermenu.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
