using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //seedData(); 
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void seedData()
        {
            var db = new DataContext();

            var initialBooks = new List<Book>()
                {
                    new Book { Title = "Hamlet", Description = "Hamlet is a tragedy by William Shakespeare, believed to have been written between 1599 and 1601. The play, set in Denmark, recounts how Prince Hamlet exacts revenge on his uncle Claudius, who has murdered Hamlet's father, the King, and then taken the throne and married Hamlet's mother. The play vividly charts the course of real and feigned madness-from overwhelming grief to seething rage-and explores themes of treachery, revenge, incest, and moral corruption.", Price = 6, Rating = 7, ReleaseYear = 2016, Image = "https://images-na.ssl-images-amazon.com/images/I/41IETeONh-L._SX331_BO1,204,203,200_.jpg", AuthorId = 16 },
                };
            db.AddRange(initialBooks);
            db.SaveChanges();

            var initialArtists = new List<Author>()
                {

                    new Author { Name = "Arthur Miller", DateOfBirth = "17 October 1915", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/Arthur-miller.jpg/220px-Arthur-miller.jpg", BookId = 67 }
                };
            db.AddRange(initialArtists);
            db.SaveChanges();

            /*var initialGenres = new List<Genre>()
            {
                new Genre { Title = "Fantasy", BookId = 10}
            };
            db.AddRange(initialGenres);
            db.SaveChanges();*/
        }
        public static void CreateBook(BookCreateViewModel book)
        {
            var db = new DataContext();

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

            db.Add(newBook);
            db.SaveChanges();
        }
    }
}