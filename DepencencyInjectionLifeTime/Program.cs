using DepencencyInjectionLifeTime.Models;

var builder = WebApplication.CreateBuilder(args);

// DepencyInjectionLifeTime => containera eklenen instancelerin yaþam süreci...

//AddTransient => instacelerin sürekli oluþutulmasýdýr. 
//AddScoped    => request bazlý instance'dir. geçerli requestte tek bir instance oluþurulup daðýtýlýr...
//AddSingleton => tek instance'dir. Uygulama baþlalýtýlðýnda instance oluþuturulur ve süreki ayný instance kullanýr. Uyguluma stop olana kadar o instance geçerlidir... (Dikkatli kullanmak gerekir
//
//
//)

builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<OgrenciIslemleri>(); // instancei servise ekle...instance bekleyenen yerlere yeni instancelar oluþuturur.
//builder.Services.AddScoped<OgrenciIslemleri>(); // Request bazlý instance. geçerli requestte tek bir instance oluþturulur ve daðýtýlýr...
builder.Services.AddSingleton<OgrenciIslemleri>(); // uygulama start olduðunda tek bir instance oluþturulur. bu instance uyuglama stop olana kadar kullanýlýr...

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(c =>
{
    c.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}"
        //,defaults: new { controller = "Home", Action = "Index" }
        );
});

app.Run();
