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

                  

                    new Book { Title = "Fifty Shades of Freed", Description ="When unworldly student Anastasia Steele first encountered the driven and dazzling young entrepreneur Christian Grey it sparked a sensual affair that changed both of their lives irrevocably. Shocked, intrigued, and, ultimately, repelled by Christian’s singular erotic tastes, Ana demands a deeper commitment. Determined to keep her, Christian agrees.Now, Ana and Christian have it all—love, passion, intimacy, wealth, and a world of possibilities for their future. But Ana knows that loving her Fifty Shades will not be easy, and that being together will pose challenges that neither of them would anticipate. Ana must somehow learn to share Christian’s opulent lifestyle without sacrificing her own identity. And Christian must overcome his compulsion to control as he wrestles with the demons of a tormented past.Just when it seems that their strength together will eclipse any obstacle, misfortune, malice, and fate conspire to make Ana’s deepest fears turn to reality.", Price = 6, Rating = 5, ReleaseYear = 2012, Image = "https://upload.wikimedia.org/wikipedia/en/thumb/9/91/Fifty_Shades_Freed_book_cover.png/220px-Fifty_Shades_Freed_book_cover.png", AuthorId = 41 },
 
                };
                db.AddRange(initialBooks);
                db.SaveChanges();

               var initialArtists = new List<Author>()
                {

                    new Author { Name = "E.L.James", DateOfBirth = "7 March 1963", Image = "https://images-na.ssl-images-amazon.com/images/I/517nrccxRXL._UX250_.jpg", BookId = 52 }
                };
                db.AddRange(initialArtists);
                db.SaveChanges(); 

                var initialGenres = new List<Genre>()
                {
                    new Genre { Title = "Romance", BookId = 54}
                };
                db.AddRange(initialGenres);
                db.SaveChanges();
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