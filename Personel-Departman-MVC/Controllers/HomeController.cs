using Microsoft.AspNetCore.Mvc;

namespace Personel_Departman_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }
    }
}
