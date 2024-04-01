using AppDevGCD1104.Models;
using AppDevGCD1104.Models.ViewModels;
using AppDevGCD1104.Repository;
using AppDevGCD1104.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AppDevGCD1104.Controllers
{
    public class BookController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		public BookController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Book> myList = _unitOfWork.BookRepository.GetAll("Category").ToList();
			return View(myList);
		}
		public IActionResult Create()
		{
			BookVM bookVM = new BookVM()
			{
				Categories = _unitOfWork.CategoryRepository.GetAll().Select(c=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
				{
					Text = c.Name,
					Value = c.Id.ToString(),
				}),
				Book = new Book()
			};
			return View(bookVM);
		}
		[HttpPost]
		public IActionResult Create(BookVM bookVM)
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.BookRepository.Add(bookVM.Book);
                _unitOfWork.BookRepository.Save();
				TempData["success"] = "Book created successfully";
				return RedirectToAction("Index");
			}
			bookVM.Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
			{
				Text = c.Name,
				Value = c.Id.ToString(),
			});
            return View(bookVM);
		}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
            BookVM bookVM = new BookVM()
            {
                Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
                Book = _unitOfWork.BookRepository.Get(c => c.Id == id)
			};
            bookVM.Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            });
            return View(bookVM);
       
		}
		[HttpPost]
		public IActionResult Edit(BookVM bookVM)
		{

			if (ModelState.IsValid)
			{
                _unitOfWork.BookRepository.Update(bookVM.Book);
                _unitOfWork.Save();
				TempData["success"] = "Book edited successfully";
				return RedirectToAction("Index");
			}
			return View(bookVM);
		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Book? Book = _unitOfWork.BookRepository.Get(c => c.Id == id,"Category");
			if (Book == null)
			{
				return NotFound();
			}
			return View(Book);
		}
		[HttpPost]
		public IActionResult Delete(Book Book)
		{

            _unitOfWork.BookRepository.Delete(Book);
            _unitOfWork.Save();
			TempData["success"] = "Book deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
