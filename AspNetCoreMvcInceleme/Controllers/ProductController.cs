using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcInceleme.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Sayfa()
        {
            return View();
        }

        public IActionResult Detay(string kategori, string title, string ilanno)
        {
            return View();
        }
    }
}
