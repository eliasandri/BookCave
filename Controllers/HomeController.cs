using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private BookService _bookService;

        public HomeController()
        {
            _bookService = new BookService();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();

            return View(books);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details()
        {
            return View();
        }

        /*       public IActionResult Delete()
               {
                   _bookService.Delete();
                   return View("Index");
               }*/

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult TermsAndConditions()
        {
            return View();
        }
    }
}
