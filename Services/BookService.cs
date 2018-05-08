using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

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
        
        public List<BookListViewModel> Filter(string orderBy)
    {
        var book = _bookRepo.Filter(orderBy);
        return book;
    }
        public void CreateBook(BookCreateViewModel book)
        {
            _bookRepo.CreateBook(book);
        }
        public void Delete()
        {
            _bookRepo.Delete();
        }
    }
}