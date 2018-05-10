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
        public List<GenreListViewModel> GetAllGenres()
        {
            var genres = _genreRepo.GetAllGenres();
            return genres;
        }

        public List<GenreDetailsViewModel> GetAllGenreDetails()
        {
            var genres = _genreRepo.GetAllGenreDetails();
            return genres;
        }
    }
}