using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using BookCave.Data.EntityModels;

namespace BookCave.Services
{
    public class BookService
    {
        private BookRepo _bookRepo;
        public BookService()
        {
            _bookRepo = new BookRepo();
        }
        public List <BookListViewModel> GetAllBooks()
        {
            var books = _bookRepo.GetAllBooks();
            
            return books;
        }
        public List<BookDetailsViewModel> GetAllBooksDetails()
        {
            var books = _bookRepo.GetAllBooksDetails();
            return books;
        }
        public List<BookTop10ViewModel> GetAllTop10Books()
        {
            var books = _bookRepo.GetAllTop10Books();
            return books;
        }
        public List<BookTop5ViewModel> GetTop5Books()
        {
            var books = _bookRepo.GetTop5Books();
            return books;
        }       
        public List<BookListViewModel> Filter(string orderBy)
        {
            var book = _bookRepo.Filter(orderBy);
            return book;
        }
        
        public BookDetailsViewModel GetBookWithId(int? id)
        {
            var book = _bookRepo.GetBookWithId(id);
            return book;

        }
       
        public void DeleteBook(BookDetailsViewModel book)
        {
            _bookRepo.DeleteBook(book);
        }
        public void Delete()
        {
            _bookRepo.Delete();
        }
        public List<BookListViewModel> GetBookByLayoutSearch(string layoutsearch)
        {
            var book = _bookRepo.GetBookByLayoutSearch(layoutsearch);
            return book;
        }
        public void CreateBookComment(BookDetailsViewModel book)
        {
              _bookRepo.CreateBookComment(book);
        }
        public List<Comment> GetReviews(int? bookId)
        {
            var book = _bookRepo.GetReviews(bookId);
            return book;
        }
    }
}