using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
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
            var books = _bookService.GetAllBooksDetails();
            var book = new BookDetailsViewModel();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].BookId == id)
                {
                    book = books[i];
                }
            }
            return View(book);
        }

        public IActionResult Top10()
        {
            var books = _bookService.GetAllTop10Books();
            return View(books);
        }
    }
}