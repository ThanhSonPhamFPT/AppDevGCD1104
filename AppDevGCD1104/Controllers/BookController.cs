using AppDevGCD1104.Models;
using AppDevGCD1104.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AppDevGCD1104.Controllers
{
    public class BookController : Controller
    {
		private readonly IBookRepository _BookRepository;
		public BookController(IBookRepository BookRepository)
		{
			_BookRepository = BookRepository;
		}
		public IActionResult Index()
		{
			List<Book> myList = _BookRepository.GetAll().ToList();
			return View(myList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Book Book)
		{

			if (ModelState.IsValid)
			{
				_BookRepository.Add(Book);
				_BookRepository.Save();
				TempData["success"] = "Book created successfully";
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Book? Book = _BookRepository.Get(c => c.Id == id);
			if (Book == null)
			{
				return NotFound();
			}
			return View(Book);
		}
		[HttpPost]
		public IActionResult Edit(Book Book)
		{

			if (ModelState.IsValid)
			{
				_BookRepository.Update(Book);
				_BookRepository.Save();
				TempData["success"] = "Book edited successfully";
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
			Book? Book = _BookRepository.Get(c => c.Id == id);
			if (Book == null)
			{
				return NotFound();
			}
			return View(Book);
		}
		[HttpPost]
		public IActionResult Delete(Book Book)
		{

			_BookRepository.Delete(Book);
			_BookRepository.Save();
			TempData["success"] = "Book deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
