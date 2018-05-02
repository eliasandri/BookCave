using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Data;
using System.Linq;

namespace BookCave.Repositories
{
    public class AuthorRepo
    {
        private DataContext _db; 

        public AuthorRepo()
        {
            _db = new DataContext();
        }

        public List<AuthorListViewModel> GetAllAuthors()
        {
            var authors = (from a in _db.Authors
                          select new AuthorListViewModel
                          {
                              Id = a.Id,
                              Name = a.Name,
                              DateOfBirth = a.DateOfBirth
                          }).ToList();

             return authors;
        }
    }
}