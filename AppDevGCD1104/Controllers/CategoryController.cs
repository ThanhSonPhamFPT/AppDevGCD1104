using AppDevGCD1104.Data;
using AppDevGCD1104.Models;
using AppDevGCD1104.Repository;
using AppDevGCD1104.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AppDevGCD1104.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> myList = _categoryRepository.GetAll().ToList();
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
                _categoryRepository.Add(category);
                _categoryRepository.Save();
				TempData["success"] = "Category created successfully";
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
            Category? category = _categoryRepository.Get(c=>c.Id==id);
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
				_categoryRepository.Update(category);
				_categoryRepository.Save();
				TempData["success"] = "Category edited successfully";
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
			Category? category = _categoryRepository.Get(c => c.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}
		[HttpPost]
		public IActionResult Delete(Category category)
		{

				_categoryRepository.Delete(category);
				_categoryRepository.Save();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");
		}

	}
}
