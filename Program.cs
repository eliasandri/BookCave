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
                    new Book { Title = "Titanic", Description = "geggjud bod", Price = 300, Rating = 9, ReleaseYear = 1990, Image = "", AuthorId = 1 },
                };
                db.AddRange(initialBooks);
                db.SaveChanges();

                var initialArtists = new List<Author>()
                {
                    new Author { Name = "Elias", DateOfBirth = "25 mars 1996", Image = "", BookId = 1 }
                };
                db.AddRange(initialArtists);
                db.SaveChanges();
        }
    }
}