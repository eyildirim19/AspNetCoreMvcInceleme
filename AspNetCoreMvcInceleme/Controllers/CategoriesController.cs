using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcMiddleware.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult List(int id)
        {
            return View();
        }
    }
}