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
        return books;
        }
        public List<BookListViewModel> Filter(string orderBy)
        {
            if(orderBy == "PriceH2L")
            {
            var filtersearch = (from a in _db.Books
                                join mr in _db.Authors on a.AuthorId equals mr.Id
                                orderby a.Price descending
                                select new BookListViewModel
                                {
                                    BookId = a.Id,
                                    Title = a.Title,
                                    AuthorId = a.Id,
                                    Author = mr.Name,
                                    Rating = a.Rating,
                                    Image = a.Image,
                                    Price = a.Price,
                                }).ToList();
                        return filtersearch;
            }
            else if(orderBy == "PriceL2H")
            {
                var filtersearch = (from a in _db.Books
                                    join mr in _db.Authors on a.AuthorId equals mr.Id
                                    orderby a.Price 
                                    select new BookListViewModel
                                    {
                                    BookId = a.Id,
                                    Title = a.Title,
                                    AuthorId = a.Id,
                                    Author = mr.Name,
                                    Rating = a.Rating,
                                    Image = a.Image,
                                    Price = a.Price,
                                    }).ToList();
                        return filtersearch;
            }
            else
            {
                var filtersearch = (from a in _db.Books
                                    orderby a.Title
                                    select new BookListViewModel
                                    {
                                        BookId = a.Id,
                                        Title = a.Title,
                                        AuthorId = a.Id,
                                        /*Author = a.Name,*/
                                        Rating = a.Rating,
                                        Image = a.Image,
                                        Price = a.Price,
                                    }).ToList();
                return filtersearch;
            }
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
                                         where m.Id == a.AuthorId
                                       select new AuthorListViewModel
                                       {
                                           AuthorId = a.AuthorId,
                                           Name = m.Name,
                                       }).ToList(),
                              AuthorId = ar.Id,
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
                             Image = m.Image,
                         }).Take(10).ToList();
                return books;
        }

        public List<BookTop5ViewModel> GetTop5Books()
        {
            var books = (from m in _db.Books
                        orderby m.Rating descending
                        select new BookTop5ViewModel
                        {
                            BookId = m.Id,
                            Title = m.Title,
                            Rating = m.Rating,
                            Image = m.Image,
                            GetNewest5Books = (from b in _db.Books
                                                orderby b.ReleaseYear descending
                                                select new BookNewest5ViewModel
                                                {
                                                    BookId = b.Id,
                                                    Title = b.Title,
                                                    ReleaseYear = b.ReleaseYear,
                                                    Image = b.Image,
                                                }).Take(5).ToList(),
                        }).Take(5).ToList();
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
        public void CreateBookComment(BookDetailsViewModel book)
        {
            var newComment = new Comment()
            {
                BookId = book.BookId,
                Review = book.Review,
                Ratings = book.Ratings,
            };
            Console.WriteLine(book.Ratings);
            _db.BookComments.Add(newComment);
            _db.SaveChanges();
        }

        public List<CommentViewModel> GetReviews(int? bookId)
        {
            var reviews = (from a in _db.Books
                            join b in _db.BookComments on a.Id equals b.BookId
                            where a.Id == bookId
                            select new CommentViewModel
                            {
                                BookId = b.BookId,
                                Review = b.Review,
                                Ratings = b.Ratings
                            }).ToList();
                    return reviews;
        }
      /*  public List<Comment> GetRatings(int? bookId)
        {
            var ratings = (from m in _db.BookComments
                            where m.BookId == bookId
                            orderby m.Ratings
                            select new Comment
                    {
                        Id  = m.Id,
                        BookId = m.BookId,
                        Ratings = m.Ratings,
                    }).ToList();
            return ratings;
        }*/
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
        public void DeleteBook(BookDetailsViewModel book)
        {
            Console.WriteLine(book.AuthorId);
            Console.WriteLine(book.Title);
            Console.WriteLine(book.Description);
            Console.WriteLine(book.Price);
            Console.WriteLine(book.GenreId);
            Console.WriteLine(book.AuthorId);

            var deletedBook = (from m in _db.Books
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

                 _db.Books.Remove(deletedBook);
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

        public List<BookListViewModel> GetBookByLayoutSearch(string layoutsearch)
        {
            var layoutresults = (from a in _db.Books
                          join b in _db.Authors on a.AuthorId equals b.Id
                          select new BookListViewModel
                          {
                            BookId = a.Id,
                            Title = a.Title,
                            Author = b.Name,
                            AuthorId = b.Id,
                            Rating = a.Rating,
                            Image = a.Image,
                            Price = a.Price,
                          }
                        );
            if (!string.IsNullOrEmpty(layoutsearch))
            {
                layoutresults = layoutresults.Where(a => a.Title.ToLower().Contains(layoutsearch.ToLower()));
            }
            return layoutresults.ToList();
        }
         public List<BookInOrderViewModel> GetBooksInUserOrder()
        {
            var Books = (from b in _db.Books
                        join br in _db.OrderDetails on b.Id equals br.ItemId
                        where b.Id == br.ItemId
                        select new BookInOrderViewModel
                        {
                            BookId = b.Id,
                            BookTitle = b.Title,
                            BookPrice = b.Price,
                        }).ToList();
            return Books;
        }
    }
}