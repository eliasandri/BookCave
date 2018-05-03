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
        public List<GenreListViewModel> GetGenre()
        {
            var genres = (from g in _db.Genres
                          select new GenreListViewModel
                          {
                              GenreId = g.GenreId,
                              Drama = g.Drama,
                              Adventure = g.Adventure,
                              /*Children = g.Children,
                              Action = g.Action,
                              StudyBooks = g.StudyBooks,
                              Horror = g.Horror,
                              Romance = g.Romance,
                              Mystery = g.Mystery,
                              ScienceFiction = g.ScienceFiction,
                              Guide = g.Guide*/
                          }).ToList();
            return genres;
        }
    }
}