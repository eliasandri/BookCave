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

        
        public IActionResult Index()
        {
            var authors = _authorService.GetAllAuthors();
            return View(authors);
        }

        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var authors = _authorService.GetAllAuthorsDetails();

            for (int i = 0; i < authors.Count; i++)
            {
                if (authors[i].AuthorId == id)
                {
                    return View(authors);
                }
            }
            return View("Error");
        }

        /*        public IActionResult Delete()
                {
                    _authorService.Delete();
                    return View("Index");
                }*/
    }
}