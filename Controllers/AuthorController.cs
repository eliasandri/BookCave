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
    public class AuthorController : Controller
    {
        private AuthorService _authorService;

        public AuthorController()
        {
            _authorService = new AuthorService();
        }

        public IActionResult Index()
        {
            var authors = _authorService.GetAllAuthors();
            return View(authors);
        }

/*        public IActionResult Delete()
        {
            _authorService.Delete();
            return View("Index");
        }*/
    }
}