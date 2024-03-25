using AppDevGCD1104.Data;
using AppDevGCD1104.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppDevGCD1104.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> myList = _dbContext.Categories.ToList();
            return View(myList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create(Category category)
		{
            if (category.Name == category.Description)
            {
                ModelState.AddModelError("Description", "Description must be different than Name");
            }
            if(ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
			return View();
		}

	}
}
