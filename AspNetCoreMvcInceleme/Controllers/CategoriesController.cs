using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcInceleme.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult List(int id)
        {
            return View();
        }
    }
}