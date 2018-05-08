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
        public List<BookTop5ViewModel> GetTop5Books()
        {
            var books = _bookRepo.GetTop5Books();
            return books;
        }
        public List<BookNewest5ViewModel> GetNewest5Books()
        {
            var newBooks = _bookRepo.GetNewest5Books();
            return newBooks;
        }
        public void CreateBook(BookCreateViewModel book)
        {
            _bookRepo.CreateBook(book);
        }
        public BookDetailsViewModel GetBookWithId(int? id)
        {
            var book = _bookRepo.GetBookWithId(id);
            return book;

        }
        public void EditBook(BookDetailsViewModel book)
        {
            _bookRepo.EditBook(book);
        }
        public void DeleteBook(BookDetailsViewModel book)
        {
            _bookRepo.DeleteBook(book);
        }
        public void Delete()
        {
            _bookRepo.Delete();
        }
    }
}