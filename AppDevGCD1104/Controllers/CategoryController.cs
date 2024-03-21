using Microsoft.AspNetCore.Mvc;

namespace AppDevGCD1104.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
