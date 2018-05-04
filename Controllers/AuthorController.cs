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
    public class AuthorController : Controller
    {
        private AuthorService _authorService;

        public AuthorController()
        {
            _authorService = new AuthorService();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var authors = _authorService.GetAllAuthors();
            return View(authors);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Details()
        {
            return View();
        }

        /*        public IActionResult Delete()
                {
                    _authorService.Delete();
                    return View("Index");
                }*/
    }
}