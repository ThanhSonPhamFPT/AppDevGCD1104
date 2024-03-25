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
		public IActionResult Edit(int? id)
		{
            if (id == null||id ==0)
            {
                return NotFound();
            }
            Category? category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
			return View(category);
		}
		[HttpPost]
		public IActionResult Edit(Category category)
		{
			
			if (ModelState.IsValid)
			{
				_dbContext.Categories.Update(category);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? category = _dbContext.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}
		[HttpPost]
		public IActionResult Delete(Category category)
		{

				_dbContext.Categories.Remove(category);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
		}

	}
}
