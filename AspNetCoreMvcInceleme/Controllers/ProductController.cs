using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcInceleme.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Sayfa()
        {
            return View();
        }
    }
}
