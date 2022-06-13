using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcInceleme.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
