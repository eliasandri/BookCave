using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Data;
using System.Linq;

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
            var books = (from m in _db.Books
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
        }
    }
}