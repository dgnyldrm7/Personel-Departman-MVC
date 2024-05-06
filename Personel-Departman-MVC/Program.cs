using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Personel_Departman_MVC.Models.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext Connection!
builder.Services.AddDbContext<DataBaseContext>();


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
    pattern: "personel/delete/{id?}", // Farklý bir desen kullanarak silme iþlemi için
    defaults: new { controller = "Personel", action = "DeletePersonel" }
);

//Personel Guncelleme
app.MapControllerRoute(
    name: "PersonelGuncelleme",
    pattern: "personel/guncelleme/{id?}", // Farklý bir desen kullanarak silme iþlemi için
    defaults: new { controller = "Personel", action = "Guncelleme" }
);

//Hakkimizda
app.MapControllerRoute(
    name: "Hakkimizda",
    pattern: "hakkimizda", // Farklý bir desen kullanarak silme iþlemi için
    defaults: new { controller = "Home", action = "Hakkimizda" }
);





//default route:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}"   );

app.Run();
