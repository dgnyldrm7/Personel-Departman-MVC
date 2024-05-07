using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Personel_Departman_MVC.Models.DatabaseContext;
using Personel_Departman_MVC.Models.Entity;

namespace Personel_Departman_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PersonelController : Controller
    {
        private readonly DataBaseContext _context;
        public PersonelController(DataBaseContext context)
        {
            _context = context;
        }

        //List Result!
        public IActionResult Anasayfa()
        {
            var datas = _context.Personels.ToList();

            return View(datas);
        }


        //DeleteResult!
        [HttpPost]
        public async Task<IActionResult> DeletePersonel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _context.Personels.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            _context.Personels.Remove(data);
            await _context.SaveChangesAsync();

            return RedirectToAction("Anasayfa");
        }






        //Details Result
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var datas = await _context.Personels
                .Include(x => x._departman)
                .FirstOrDefaultAsync( x=>x.Id == id);

            if(datas == null)
            {
                return NotFound();
            }

            return View(datas);
        }






        //Add new personel!
        [HttpGet]
        public IActionResult Result()
        {
 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Result(Personel personel)
        {
   

            if (ModelState.IsValid) //ModelState.IsValid  hiçbir hata yoku temsil eder
            {
                _context.Personels.Add(personel);
                await _context.SaveChangesAsync();

                ViewBag.SuccessMessage = "Personel başarıyla kaydedildi.";
                ViewBag.ShowSuccessModal = true; // Modalı göstermek için bayrak
            }
            else
            {
                return View(personel);
            }

            return RedirectToAction("Anasayfa");
        }







        //Guncelleme Method!
        [HttpGet]
        public async Task<IActionResult> Guncelleme(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datas = await _context.Personels.Include(x => x._departman).FirstOrDefaultAsync(x => x.Id == id);

            if(datas == null)
            {
                return NotFound();
            }

            return View(datas);
        }

        [HttpPost]
        //Guncelleme Method!
        public async Task<IActionResult> Guncelleme(int? id ,Personel personel)
        {
            if(id != personel.Id)
            {
                return NotFound();
            }

            var datas = await _context.Personels
                .Include(x => x._departman)
                .FirstOrDefaultAsync(x => x.Id == personel.Id);

            if(datas == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                datas.Name = personel.Name;
                datas.lName = personel.Name;
                datas.Email = personel.Email;
                datas.DepartmanId = personel.DepartmanId;
                datas.ConfirmPassword = personel.ConfirmPassword;
                datas.Password = personel.Password;

                await _context.SaveChangesAsync();

                return RedirectToAction("Anasayfa");
            }
            else
            {
                return View(personel);
            }

            

            return RedirectToAction("Anasayfa");
        }


    }
}
