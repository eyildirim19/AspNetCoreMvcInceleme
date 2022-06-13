var builder = WebApplication.CreateBuilder(args);


// dependecny injection servisleri....
//builder.Services.AddControllers(); // controller yapýsý
builder.Services.AddControllersWithViews();


var app = builder.Build();

// middlewareleri kullanýyoruz.. Middleware metotlarý use ile baþlar..

app.UseRouting();

app.UseEndpoints(conf =>
{

    conf.MapControllerRoute(
        name: "urun",
        pattern: "urunlerim/{action}",
        defaults: new { controller = "Product", action = "Index" }
        );

    conf.MapControllerRoute(
        name: "default", // default route bütün controllerlar için kullanýlýr.
        pattern: "{controller}/{action}",
        defaults: new { controller = "Home", action = "Index" }
        );
});

app.Run();
