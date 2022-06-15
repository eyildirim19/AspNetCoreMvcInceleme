using DepencencyInjectionLifeTime.Models;

var builder = WebApplication.CreateBuilder(args);

// DepencyInjectionLifeTime => containera eklenen instancelerin ya�am s�reci...

//AddTransient => instacelerin s�rekli olu�utulmas�d�r. 
//AddScoped    => request bazl� instance'dir. ge�erli requestte tek bir instance olu�urulup da��t�l�r...
//AddSingleton => tek instance'dir. Uygulama ba�lal�t�l��nda instance olu�uturulur ve s�reki ayn� instance kullan�r. Uyguluma stop olana kadar o instance ge�erlidir... (Dikkatli kullanmak gerekir
//
//
//)

builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<OgrenciIslemleri>(); // instancei servise ekle...instance bekleyenen yerlere yeni instancelar olu�uturur.
//builder.Services.AddScoped<OgrenciIslemleri>(); // Request bazl� instance. ge�erli requestte tek bir instance olu�turulur ve da��t�l�r...
builder.Services.AddSingleton<OgrenciIslemleri>(); // uygulama start oldu�unda tek bir instance olu�turulur. bu instance uyuglama stop olana kadar kullan�l�r...

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
