using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private BookService _bookService;

        public BookController()
        {
            _bookService = new BookService();
        }

        public IActionResult Shop()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            return View();
        }
    }
}