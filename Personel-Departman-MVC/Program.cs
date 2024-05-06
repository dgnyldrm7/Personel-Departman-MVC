using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Personel_Departman_MVC.Models.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext Connection!
builder.Services.AddDbContext<DataBaseContext>();


//Cookie Configure Setting
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie( options =>
{
    options.Cookie.Name = "mvcProject";
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/Account/AccesDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
} );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


//added middleware struct!
app.UseAuthentication();
app.UseAuthorization();






//Departman Listeleme:
app.MapControllerRoute(
    name: "departmanList",
    pattern: "departman",
    defaults: new { controller = "Departman", action = "Index" }
    );



//Personel Listeleme:
app.MapControllerRoute(
    name: "personelList",
    pattern: "personel",
    defaults: new { controller = "Personel", action = "Anasayfa" }
    );

//Personel Yeni Ekleme
app.MapControllerRoute(
    name: "personelNew",
    pattern: "/personel/yeni-personel",
    defaults: new { controller = "Personel", action = "Result" }
    );





// Personel Detaylarý
app.MapControllerRoute(
    name: "PersonelDetails",
    pattern: "personel/details/{id?}", // {id?} ile id parametresini isteðe baðlý hale getiriyoruz
    defaults: new { controller = "Personel", action = "Details" }
);

// Personel Silmek
app.MapControllerRoute(
    name: "PersonelDelete",
    pattern: "personel/delete/{id?}", 
    defaults: new { controller = "Personel", action = "DeletePersonel" }
);

//Personel Guncelleme
app.MapControllerRoute(
    name: "PersonelGuncelleme",
    pattern: "personel/guncelleme/{id?}", 
    defaults: new { controller = "Personel", action = "Guncelleme" }
);

//Hakkimizda
app.MapControllerRoute(
    name: "Hakkimizda",
    pattern: "hakkimizda", 
    defaults: new { controller = "Home", action = "Hakkimizda" }
);


//Giriþ - Login
app.MapControllerRoute(
    name: "Login",
    pattern: "login", 
    defaults: new { controller = "Login", action = "Login" }
);





//default route:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}"   );

app.Run();
