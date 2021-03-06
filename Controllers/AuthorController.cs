using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using BookCave.Models.ViewModels;

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
        public IActionResult FilterSearch(string orderBy = "")
        {
            var authors = _authorService.FilterSearch(orderBy);
            return View("Index", authors);
        }
        public IActionResult Details(int? id)
        {
            var allAuthors = _authorService.GetAllAuthors();
            if (id > allAuthors.Count)
            {
                return View("Error");
            }

            var authors = _authorService.GetAllAuthorsDetails();
            var author = new AuthorDetailsViewModel();
            for (int i = 0; i < authors.Count; i++)
            {
                if (authors[i].AuthorId == id)
                {
                    author = authors[i];
                }
            }
            return View(author);
        }

        /*public IActionResult Delete()
        {
            _authorService.Delete();
            return View("Index");
        }/* */
    }
}