using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Data;
using BookCave.Data.EntityModels;
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
                           join ar in _db.Books on a.BookId equals ar.Id
                           select new AuthorListViewModel
                           {
                              AuthorId = a.Id,
                              Name = a.Name,
                              DateOfBirth = a.DateOfBirth,
                              Image = a.Image,
                              Book = ar.Title,
                              BookId = ar.Id
                           }).ToList();

             return authors;
        }

        public void Delete()
        {
            var authors = (from a in _db.Authors
                          select new Author
                          {
                               Id = a.Id,
                               Name = a.Name,
                               DateOfBirth = a.DateOfBirth
                          }).ToList();

            _db.Authors.RemoveRange(authors);
            _db.SaveChanges();
        }
    }
}