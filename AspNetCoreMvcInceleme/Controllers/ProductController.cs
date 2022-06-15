using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcMiddleware.Controllers
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
