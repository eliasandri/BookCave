using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModels;
using BookCave.Data;
using BookCave.Data.EntityModels;
using System.Linq;
using System;

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

        public IActionResult QuickSearch(string searchTerm)
        {
            var books = _bookService.GetBookByLayoutSearch(searchTerm);
            if (!books.Any())
            {
                return View("NotFound");
            }
            return View("Shop", books);
        }
        public IActionResult Details(int? id)
        {
            Console.WriteLine(id);
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
            book.Reviews = _bookService.GetComments(id);
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Details(BookDetailsViewModel book, int id)
        {
            
            if (ModelState.IsValid)
            {
                book.BookId = id;
                _bookService.CreateBookComment(book);
                return RedirectToAction("Details");
            }
            return View();
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

        public IActionResult Filter(string orderBy = "")
        {
            var books = _bookService.Filter(orderBy);
            return View("Shop", books);
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
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            //int? _id = id;
            var book = _bookService.GetBookWithId(id);
            //var db = new DataContext();
            //Book book = db.Books.Single(model => model.Id == id);

            if (book == null)
            {
                return View("Error");
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(BookDetailsViewModel book)
        {
            if (ModelState.IsValid)
            {
                /*var db = new DataContext();
                db.Books.Update(book);
                db.SaveChanges();*/
                _bookService.EditBook(book);

                return RedirectToAction("Shop");
            }
            return View("Book");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var book = _bookService.GetBookWithId(id);
            if (book == null)
            {
                return View("Error");
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetBookWithId(id);
            Console.WriteLine(book.BookId);
            if (ModelState.IsValid)
            {
                /*var db = new DataContext();
                db.Books.Update(book);
                db.SaveChanges();*/
                _bookService.DeleteBook(book);

                return RedirectToAction("Shop");
            }
            return View("Book");
        }
    }
}