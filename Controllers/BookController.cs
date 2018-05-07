using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModels;
using BookCave.Data;
using BookCave.Data.EntityModels;

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

        [HttpGet]
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookCreateViewModel book)
        {
            if (ModelState.IsValid)
            {
                var db = new DataContext();
                var newBook = new Book()
                {
                    Title = book.Title,
                    Description = book.Description,
                    Price = book.Price,
                    Rating = book.Rating,
                    ReleaseYear = book.ReleaseYear,
                    AuthorId = book.AuthorId,
                    GenreId = book.GenreId,
                    Image = book.Image
                };
                db.Add(newBook);
                db.SaveChanges();
                return RedirectToAction("Shop");
            }
            return View();
        }
    }
}