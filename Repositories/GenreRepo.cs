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
            var genres = (from g in _db.Genre
                          select new GenreListViewModel
                          {
                              Drama = g.drama,
                              Adventure = g.adventure,
                              Children = g.children,
                              Action = g.action,
                              StudyBooks = g.studyBooks,
                              Horror = g.horror,
                              Romance = g.romance,
                              Mystery = g.mystery,
                              ScienceFiction = g.scienceFiction,
                              Guide = g.guide
                          }).ToList();
            return genres;
        }
    }
}