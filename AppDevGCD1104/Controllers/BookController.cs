using Microsoft.AspNetCore.Mvc;

namespace AppDevGCD1104.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
