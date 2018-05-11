using System.Collections.Generic;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class AdminService
    {
        private AdminRepo _adminRepo;

        public AdminService()
        {
            _adminRepo = new AdminRepo();
        }
        public void CreateBook(BookCreateViewModel book)
        {
            _adminRepo.CreateBook(book);
        }
        public BookDetailsViewModel GetBookWithId(int? id)
        {
            var book = _adminRepo.GetBookWithId(id);
            return book;

        }
        public void EditBook(BookDetailsViewModel book)
        {
            _adminRepo.EditBook(book);
        }
        public List<BookListViewModel> GetAllBooks()
        {
            var books = _adminRepo.GetAllBooks();

            return books;
        }
        public void DeleteBook(BookDetailsViewModel book)
        {
            _adminRepo.DeleteBook(book);
        }
    }
}