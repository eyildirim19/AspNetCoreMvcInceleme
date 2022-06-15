using DepencencyInjectionLifeTime.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepencencyInjectionLifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly OgrenciIslemleri ogrenciIslemleri;
        private readonly OgrenciIslemleri ogrenciIslemleri1;
        public HomeController(
            OgrenciIslemleri _ogrenciIslemleri,
            OgrenciIslemleri _ogrenciIslemleri1
            )
        {
            ogrenciIslemleri = _ogrenciIslemleri;
            ogrenciIslemleri1 = _ogrenciIslemleri1;
        }

        public IActionResult Index()
        {

            string str = ogrenciIslemleri.ogrenci;
            string str2 = ogrenciIslemleri1.ogrenci;

            var anonimType = new
            {
                instance1 = str,
                instance2 = str2
            };

            return Json(anonimType);
            // instancleri ayrı ayrı oluşturup öğrencilerimizi gördük. instace oluştuğunda öğrenci seçme o anki instancedeki öğrenciyi görmek içindir...

            //OgrenciIslemleri ogrenciIslemleri = new OgrenciIslemleri();
            //string o = ogrenciIslemleri.ogrenci;


            //OgrenciIslemleri ogrenciIslemleri1 = new OgrenciIslemleri();
            //string b = ogrenciIslemleri1.ogrenci;

            //OgrenciIslemleri ogrenciIslemleri2 = ogrenciIslemleri;
            //string c = ogrenciIslemleri2.ogrenci;


            return View();
        }
    }
}