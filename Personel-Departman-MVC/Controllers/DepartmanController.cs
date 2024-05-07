using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personel_Departman_MVC.Models.DatabaseContext;
using Personel_Departman_MVC.Models.Entity;

namespace Personel_Departman_MVC.Controllers
{
    [Authorize(Roles = "User")]
    public class DepartmanController : Controller
    {

        //Dependency Injection!
        private readonly DataBaseContext _context;
        public DepartmanController(DataBaseContext context)
        {
            _context = context;
        }


        //Departman List
        public IActionResult Index()
        {
            var datas = _context.Departmans.ToList();

            return View(datas);
        }




        //Delete Departman
        [Route("/delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var datas = await _context.Departmans.FindAsync(id);

            if(datas == null)
            {
                return NotFound();
            }

            _context.Departmans.Remove(datas);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Departman");
        }



        //New Departman
        [Route("departman/yeni-departman")]
        public IActionResult Newdepartman()
        {
            return View();
        }

        //New Departman
        [HttpPost]
        [Route("departman/yeni-departman")]
        public async Task<IActionResult> Newdepartman(Departman departman)
		{
            if(ModelState.IsValid)
            {
                await _context.Departmans.AddAsync(departman);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

			return View(departman);
		}





        //Departman Details
        [HttpGet]
        [Route("departman/details/{id}")]
		public async Task<IActionResult> Details(int? id)
		{
            if (id ==null)
            {
                return NotFound();
            }

            var datas = await _context
                .Departmans
                .Include(x=>x._personels)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(datas == null)
            {
                return NotFound();
            }

			return View(datas);
		}






        //Update Departman
        [HttpGet]
        [Route("departman/guncelle/{id:int}")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datas = await _context.Departmans.FirstOrDefaultAsync(x => x.Id == id);

            if (datas == null)
            {
                return NotFound();
            }

            return View(datas);
        }

        [HttpPost]
        [Route("departman/guncelle/{id:int}")]
        //Update Departman
        public async Task<IActionResult> Update(int? id , Departman departman)
        {
            if(id == null)
            {
                return NotFound();
            }

            var datas =await _context.Departmans.FindAsync(id);

            if(datas == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                datas.DepartmanName = departman.DepartmanName;
                datas.DepartmanDescription = departman.DepartmanDescription;
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(departman);
            }

            return RedirectToAction("Index");
        }











    }
}
