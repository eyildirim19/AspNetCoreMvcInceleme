using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcMiddleware.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
