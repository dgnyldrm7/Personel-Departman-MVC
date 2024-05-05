using Microsoft.AspNetCore.Mvc;
using Personel_Departman_MVC.Models.DatabaseContext;

namespace Personel_Departman_MVC.Controllers
{
    public class PersonelController : Controller
    {
        private readonly DataBaseContext _context;
        public PersonelController(DataBaseContext context)
        {
            _context = context;
        }


        public IActionResult Anasayfa()
        {
            ViewBag.degisken = "Bu bilgi , controllerdan geliyor";

            return View();
        }

    }
}
