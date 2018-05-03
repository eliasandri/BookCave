using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class GenreService
    {
        private GenreRepo _genreRepo;
        public GenreService()
        {
            _genreRepo = new GenreRepo();
        }
        public List<GenreListViewModel> GetGenre()
        {
            var genres = _genreRepo.GetGenre();
            return genres;
        }
    }
}