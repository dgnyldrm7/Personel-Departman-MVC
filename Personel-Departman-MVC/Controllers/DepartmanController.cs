using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personel_Departman_MVC.Models.DatabaseContext;

namespace Personel_Departman_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmanController : Controller
    {

        //Dependency Injection!
        private readonly DataBaseContext _context;
        public DepartmanController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var datas = _context.Departmans.ToList();

            return View(datas);
        }
    }
}
