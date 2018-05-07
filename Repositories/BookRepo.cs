using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Data;
using System.Linq;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using System;

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
        public List<BookTop10ViewModel> GetAllTop10Books()
        {
            var books = (from m in _db.Books
                         orderby m.Rating descending
                         select new BookTop10ViewModel
                         {
                             BookId = m.Id,
                             Title = m.Title,
                             Rating = m.Rating,
                         }).Take(10).ToList();

                return books;
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
        public BookDetailsViewModel GetBookToEdit(int id)
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
        public void EditBook(BookDetailsViewModel book)
        {
            
            Console.WriteLine(book.BookId);
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