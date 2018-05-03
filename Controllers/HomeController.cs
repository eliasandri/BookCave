using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        private BookService _bookService;

        public HomeController()
        {
            _bookService = new BookService(); 
        }
        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();

            return View(books);
        }

 /*       public IActionResult Delete()
        {
            _bookService.Delete();
            return View("Index");
        }*/
    }
}
