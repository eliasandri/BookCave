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
            /*var books = (from b in _db.Books
                        select new BookListViewModel
                        {
                            BookId = b.Id,
                            Name = b.Name,
                            ReleaseYear = b.ReleaseYear,
                            Author = "joi",
                            AuthorId = 2 
                        }).ToList();*/
            var books = (from m in _db.Books
                        join mr in _db.Authors on m.AuthorId equals mr.Id
                        select new BookListViewModel
                        {
                            BookId = m.Id,
                            Title = m.Title,
                            //ReleaseYear = m.ReleaseYear,
                            Author = mr.Name,
                            AuthorId = mr.Id ,
                            //Description = m.Description,
                            Price = m.Price,
                            Image = m.Image,
                            Rating = m.Rating,
                        }).ToList();
            //return books;
        
        return books;
        }

        public List<BookDetailsViewModel> GetAllBooksDetails()
        {
            var books = (from a in _db.Books
                           join ar in _db.Authors on a.AuthorId equals ar.Id
                           select new BookDetailsViewModel
                           {
                              BookId = a.Id,
                              Title = a.Title,
                              ReleaseYear = a.ReleaseYear,
                              Image = a.Image,
                              Description = a.Description,
                              Price = a.Price,
                              Rating = a.Rating,
                              Authors = (from m in _db.Authors
                                       join mr in _db.Books on m.BookId equals mr.Id
                                       where m.BookId == a.Id
                                       select m).ToList(),
                              AuthorId = ar.Id
                           }).ToList();

             return books;
        }

        public void Delete()
        {
            var books = (from a in _db.Books
                          select new Book
                          {
                              Id = a.Id,
                            Title = a.Title,
                            ReleaseYear = a.ReleaseYear,
                            AuthorId = a.AuthorId
                          }).ToList();

            _db.Books.RemoveRange(books);
            _db.SaveChanges();
        }
    }
}