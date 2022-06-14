using AspNetCoreMvcInceleme.Helpers;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


// dependecny injection servisleri....
//builder.Services.AddControllers(); // controller yapýsý
builder.Services.AddControllersWithViews();


var app = builder.Build();


// Middleware türleri...
// Use => bir sonraki middleware tetiklenir..
// Run => kýsa devre middleware'dir. sonraki middleware tetiklemez süreci bitirir..
// Map => bellirli bir pathe eriþilmek istendiðinde kullanýlýr. Use middleware içerisindeki request pathleri iflerle ayýrmak yerine map kullanýlabilir...
//MapWhen() =>belirli bir request metota (POST,GET VS.) eriþilmek istendiðinde kullanýlýr


//app.Use((context, next) =>
//{
//    string str = context.Request.Path; // requestin arasýna girip hangi pathe request atýlmýþ str deðiþkenine atadýk...

//    if (context.Request.Path == "/Admin")
//    {
//        // burada yetki kontrolü yapabiliriz...
//    }

//    return next(context); // bir sonraki middleware...
//});

//app.Map("/Admin", c =>
//{
//});

//app.UseMiddleware => kendi middlewarelerimizi tetiklemek için kullanýlýr...
//app.UseMiddleware<MyMiddleware>(); // yazdýðýmýz middleware tetikliyoruz...

// Middlewarelar IApplicationBuilder interface'sine extend edilmiþ metotlardýr. Bizde Bu interface extension metot yazar bu interface üzerinden middlewarelerimizi tetikleyebiliriz...


// middlewareleri kullanýyoruz.. Middleware metotlarý use ile baþlar..
app.UseStaticFiles(); // =>wwwroot folderýný açar

//app.Run(); // eðer burayý açarsak aþaðýdaki middlewareler tetiklenmeyecektir.


// roottaki Content Folder'i dýþarýya açtýk...
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content")),
    RequestPath = "/Content"
});

app.UseRouting();

// routing örnekleri....
app.UseEndpoints(conf =>
{

    // area routing
    conf.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );

    // not : patterndeki {} içerisinde paramtre isimleri ile actiondaki parametre nameler ayný olmalýdýr..
    conf.MapControllerRoute(
        name: "urundetay",
        pattern: "ilan/{kategori}/{title}-{ilanno}/Detay",
        defaults: new { controller = "Product", action = "Detay" }
        ); // Detay action'ýn url patterni

    conf.MapControllerRoute(
      name: "urun",
      pattern: "urunlerim/{action}",
      defaults: new { controller = "Product", action = "Index" }
      );

    // genel routing en altta olmalýdýr. özel controllerlara yazýlanlar üstte olmalýdýr. Çünkü genel bütün hepsiyle eþleþeceði için özelliþtirilmiþ routingleri ezer..

    conf.MapControllerRoute(
       name: "default", // default route bütün controllerlar için kullanýlýr.
       pattern: "{controller}/{action}/{id?}", // eðer url bu formatta olmazsa endpoint eþleþemeyeceði için controller bulunamaz..genel route'da  id alaný hepsinde olmayacaðý için {id?} yaptýk. yani ? ile id'nin opsiyonel olduðu belirtilir. url'de olmak zorunda deðil. eðer olursa patterndeki formatta göster. olmazsa id'yi eþleþtirme...
       defaults: new { controller = "Home", action = "Index" }
       );

});

app.Run();