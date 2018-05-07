using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModels;
using BookCave.Data;
using BookCave.Data.EntityModels;
using System.Linq;

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


        [Authorize(Roles = "PowerUser")]
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
                _bookService.CreateBook(book);
                return RedirectToAction("Shop");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit (int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var db = new DataContext();
            Book book = db.Books.Single(model => model.Id == id);

            if(book == null)
            {
                return View("Error");
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit (Book book)
        {
            if(ModelState.IsValid)
            {
                var db = new DataContext();
                db.Books.Update(book);
                db.SaveChanges();

                return RedirectToAction("Shop");
            }
            return View(book);
        }
    }
}