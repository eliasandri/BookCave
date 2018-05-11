using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Repositories
{
    public class AdminRepo
    {
        private DataContext _db;

        public AdminRepo()
        {
            _db = new DataContext();
        }
        public void CreateBook(BookCreateViewModel book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                Rating = book.Rating,
                ReleaseYear = book.ReleaseYear,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                Image = book.Image
            };
            _db.Add(newBook);
            _db.SaveChanges();
        }
        public void EditBook(BookDetailsViewModel book)
        {
            var editedBook = (from m in _db.Books
                              where m.Id == book.BookId
                              select new Book()
                              {
                                  Id = book.BookId,
                                  Title = book.Title,
                                  Description = book.Description,
                                  Price = book.Price,
                                  Rating = book.Rating,
                                  ReleaseYear = book.ReleaseYear,
                                  AuthorId = book.AuthorId,
                                  GenreId = book.GenreId,
                                  Image = book.Image
                              }).SingleOrDefault();
            //int id = book.BookId;
            //Book _book = _db.Books.Single(model => model.Id == id);
            _db.Books.Update(editedBook);
            _db.SaveChanges();
        }
        public BookDetailsViewModel GetBookWithId(int? id)
        {
            //var db = new DataContext();
            //var book = _db.Books.Single(model => model.Id == 1);
            var bookToEdit = (from m in _db.Books
                              where m.AuthorId == id
                              select new BookDetailsViewModel
                              {
                                  BookId = m.Id,
                                  Title = m.Title,
                                  ReleaseYear = m.ReleaseYear,
                                  Image = m.Image,
                                  Description = m.Description,
                                  Price = m.Price,
                                  Rating = m.Rating,
                                  AuthorId = m.AuthorId,
                                  GenreId = m.GenreId
                              }).FirstOrDefault();

            return bookToEdit;
        }
        public List<BookListViewModel> GetAllBooks()
        {
            var books = (from m in _db.Books
                         join mr in _db.Authors on m.AuthorId equals mr.Id
                         select new BookListViewModel
                         {
                             BookId = m.Id,
                             Title = m.Title,
                             //ReleaseYear = m.ReleaseYear,
                             Author = mr.Name,
                             AuthorId = mr.Id,
                             //Description = m.Description,
                             Price = m.Price,
                             Image = m.Image,
                             Rating = m.Rating,
                         }).ToList();
            return books;
        }
    }
}