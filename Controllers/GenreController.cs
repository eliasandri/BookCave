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
    public class GenreController : Controller
    {
        private GenreService _genreService;
        public GenreController()
        {
            _genreService = new GenreService();
        }
        public IActionResult Index()
        {
            var genres = _genreService.GetAllGenres();
            return View(genres);
        }
        public IActionResult Details(int id)
        {
            var genres = _genreService.GetAllGenreDetails();
            var genre = new GenreDetailsViewModel();
            for (int i = 0; i < genres.Count; i++)
            {
                if (genres[i].GenreId == id)
                {
                    genre = genres[i];
                }
            }
            return View(genre);
        }
    }
}