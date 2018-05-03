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
    public class GenreController : Controller
    {
        private GenreService _genreService;

        public GenreController()
        {
            _genreService = new GenreService();
        }

        public IActionResult Index()
        {
            //var genres = _genreService.GetGenre();
            return View();
        }
    }
}