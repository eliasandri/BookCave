using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Data;
using BookCave.Data.EntityModels;
using System.Linq;

namespace BookCave.Repositories
{
    public class GenreRepo
    {
        private DataContext _db;
        public GenreRepo()
        {
            _db = new DataContext();
        }
        public List<GenreListViewModel> GetAllGenres()
        {
            var genres = (from g in _db.Genres
                          join gr in _db.Books on g.BookId equals gr.Id
                          select new GenreListViewModel
                          {
                              GenreId = g.Id,
                              Title = g.Title
                          }).ToList();
                          
            return genres;
        }
    }
}