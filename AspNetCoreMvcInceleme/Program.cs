using AspNetCoreMvcInceleme.Helpers;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


// dependecny injection servisleri....
//builder.Services.AddControllers(); // controller yap�s�
builder.Services.AddControllersWithViews();


var app = builder.Build();


// Middleware t�rleri...
// Use => bir sonraki middleware tetiklenir..
// Run => k�sa devre middleware'dir. sonraki middleware tetiklemez s�reci bitirir..
// Map => bellirli bir pathe eri�ilmek istendi�inde kullan�l�r. Use middleware i�erisindeki request pathleri iflerle ay�rmak yerine map kullan�labilir...
//MapWhen() =>belirli bir request metota (POST,GET VS.) eri�ilmek istendi�inde kullan�l�r


//app.Use((context, next) =>
//{
//    string str = context.Request.Path; // requestin aras�na girip hangi pathe request at�lm�� str de�i�kenine atad�k...

//    if (context.Request.Path == "/Admin")
//    {
//        // burada yetki kontrol� yapabiliriz...
//    }

//    return next(context); // bir sonraki middleware...
//});

//app.Map("/Admin", c =>
//{
//});

//app.UseMiddleware => kendi middlewarelerimizi tetiklemek i�in kullan�l�r...
//app.UseMiddleware<MyMiddleware>(); // yazd���m�z middleware tetikliyoruz...

// Middlewarelar IApplicationBuilder interface'sine extend edilmi� metotlard�r. Bizde Bu interface extension metot yazar bu interface �zerinden middlewarelerimizi tetikleyebiliriz...


// middlewareleri kullan�yoruz.. Middleware metotlar� use ile ba�lar..
app.UseStaticFiles(); // =>wwwroot folder�n� a�ar

//app.Run(); // e�er buray� a�arsak a�a��daki middlewareler tetiklenmeyecektir.


// roottaki Content Folder'i d��ar�ya a�t�k...
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content")),
    RequestPath = "/Content"
});

app.UseRouting();

// routing �rnekleri....
app.UseEndpoints(conf =>
{

    // area routing
    conf.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );

    // not : patterndeki {} i�erisinde paramtre isimleri ile actiondaki parametre nameler ayn� olmal�d�r..
    conf.MapControllerRoute(
        name: "urundetay",
        pattern: "ilan/{kategori}/{title}-{ilanno}/Detay",
        defaults: new { controller = "Product", action = "Detay" }
        ); // Detay action'�n url patterni

    conf.MapControllerRoute(
      name: "urun",
      pattern: "urunlerim/{action}",
      defaults: new { controller = "Product", action = "Index" }
      );

    // genel routing en altta olmal�d�r. �zel controllerlara yaz�lanlar �stte olmal�d�r. ��nk� genel b�t�n hepsiyle e�le�ece�i i�in �zelli�tirilmi� routingleri ezer..

    conf.MapControllerRoute(
       name: "default", // default route b�t�n controllerlar i�in kullan�l�r.
       pattern: "{controller}/{action}/{id?}", // e�er url bu formatta olmazsa endpoint e�le�emeyece�i i�in controller bulunamaz..genel route'da  id alan� hepsinde olmayaca�� i�in {id?} yapt�k. yani ? ile id'nin opsiyonel oldu�u belirtilir. url'de olmak zorunda de�il. e�er olursa patterndeki formatta g�ster. olmazsa id'yi e�le�tirme...
       defaults: new { controller = "Home", action = "Index" }
       );

});

app.Run();