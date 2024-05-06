using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Personel_Departman_MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //Login Configure
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            string name = username;
            

            // Kullanıcı adı ve şifreyi veritabanında kontrol et
            if (IsValidUser(username, password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin"), // Kullanıcının rolünü belirle
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);



				TempData["Username"] = name;

				return RedirectToAction("Home","Home" );
            }

            // Kullanıcı adı ve şifre doğru değilse, giriş sayfasına geri dön

            return RedirectToAction("Login");
        }

        private bool IsValidUser(string username, string password)
        {
            // Kullanıcı adı ve şifreyi veritabanında kontrol et
            // Örnek olarak, sabit bir kullanıcı adı ve şifre kontrolü yapalım
            return username == "dogan" && password == "123";
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login","Login");
        }


    }
}
