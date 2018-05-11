using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModels;
using BookCave.Data;
using BookCave.Data.EntityModels;
using System.Linq;
using System;
using BookCave.Models;
using System.Diagnostics;

namespace BookCave.Controllers
{
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
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var allBooks = _bookService.GetAllBooks();
            if (id > allBooks.Count)
            {
                return View("Error");
            }
            double totalForAverage = 0;
            var books = _bookService.GetAllBooksDetails();
            
            
            var book = new BookDetailsViewModel();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].BookId == id)
                {
                    book = books[i];
                }
            book.Reviews = _bookService.GetReviews(id);
            }
            for (int i = 0; i < book.Reviews.Count; i++)
            {
                totalForAverage += book.Reviews[i].Ratings;
            }
            book.AverageRating = totalForAverage / book.Reviews.Count;

            if(double.IsNaN(book.AverageRating))
            {
                book.AverageRating = 0.0;
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Details(BookDetailsViewModel book, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            if (ModelState.IsValid)
            {
                book.BookId = id;
                _bookService.CreateBookComment(book);
                Console.WriteLine(book.Ratings);
                return RedirectToAction("Details");
            }
            return View();
        }
        public IActionResult Top10()
        {
            var books = _bookService.GetAllTop10Books();
            return View(books);
        }
        public IActionResult Filter(string orderBy = "")
        {
            var books = _bookService.Filter(orderBy);
            return View("Shop", books);
        }
        public IActionResult Error()
        {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}