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
                           }).ToList();

            return authors;
        }
        public List<AuthorListViewModel> FilterSearch(string orderby = "")
        {
            var authors = (from a in _db.Authors
                           orderby a.Name
                           select new AuthorListViewModel
                           {
                               AuthorId = a.Id,
                               Name = a.Name,
                               DateOfBirth = a.DateOfBirth
                           }).ToList();
            return authors;
        }
        public List<AuthorDetailsViewModel> GetAllAuthorsDetails()
        {
            var authors = (from a in _db.Authors
                           join ar in _db.Books on a.BookId equals ar.Id
                           select new AuthorDetailsViewModel
                           {
                              AuthorId = a.Id,
                              Name = a.Name,
                              DateOfBirth = a.DateOfBirth,
                              Image = a.Image,
                              Books = (from m in _db.Books
                                       join mr in _db.Authors on m.AuthorId equals mr.Id
                                       where m.AuthorId == a.Id
                                       select new BookDetailsViewModel
                                       {
                                        BookId = m.Id,
                                        Title = m.Title,
                                       }).ToList(),
                              BookId = ar.Id
                           }).ToList();

            return authors;
        }
        /*public List<AuthorDetailsViewModel> GetBookByLayoutSearch(string layoutsearch)
        {
            var layoutresults = (from a in _db.Authors
                          join ar in _db.Books on a.BookId equals ar.Id
                          select new AuthorDetailsViewModel
                          {
                          Name = a.Name,
                          AuthorId = a.Id,
                          DateOfBirth = a.DateOfBirth,
                          Image = a.Image,
                          Books = (from m in _db.Books
                                  join mr in _db.Authors on m.AuthorId equals mr.Id
                                  where m.AuthorId == a.Id
                                  select m).ToList(),
                            BookId = ar.Id
                          }
                        );
        if (!string.IsNullOrEmpty(layoutsearch))
        {
        layoutresults = layoutresults.Where(a => a.Name.ToLower().Contains(layoutsearch.ToLower()));
        }
        return layoutresults.ToList();
        }*/
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