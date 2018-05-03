using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Data;
using System.Linq;
using BookCave.Data.EntityModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db; 

        public BookRepo()
        {
            _db = new DataContext();
        }
        public List <BookListViewModel> GetAllBooks()
        {
            var books = (from b in _db.Books
                        select new BookListViewModel
                        {
                            BookId = b.Id,
                            Name = b.Name,
                            ReleaseYear = b.ReleaseYear,
                            Author = "joi",
                            AuthorId = 2 
                        }).ToList();
            /*var books = (from m in _db.Books
                        join mr in _db.Authors on m.AuthorId equals mr.Id
                        select new BookListViewModel
                        {
                            BookId = m.Id,
                            Name = m.Name,
                            ReleaseYear = m.ReleaseYear,
                            Author = mr.Name,
                            AuthorId = mr.Id 
                        }).ToList();
            return books;
        */
        return books;
        }

        public void Delete()
        {
            var books = (from a in _db.Books
                          select new Book
                          {
                              Id = a.Id,
                            Name = a.Name,
                            ReleaseYear = a.ReleaseYear,
                            AuthorId = a.AuthorId
                          }).ToList();

            _db.Books.RemoveRange(books);
            _db.SaveChanges();
        }
    }
}