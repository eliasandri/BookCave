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
                    new Book { Title = "Jamie's 30 minute meals", Description = "Jamie Oliver will teach you how to make good food super fast! Jamie proves that, by mastering a few tricks and being organized and focused in the kitchen, it is absolutely possible, and easy, to get a complete meal on the table in the same amount of time you'd normally spend making one dish!", Price = 5, Rating = 6, ReleaseYear = 2010, Image = "", AuthorId = 17 },
                };
                db.AddRange(initialBooks);
                db.SaveChanges();

               var initialArtists = new List<Author>()
                {
                    new Author { Name = "Jamie Oliver", DateOfBirth = "27 May 1975", Image = "", BookId = 23 }
                };
                db.AddRange(initialArtists);
                db.SaveChanges(); 
        }
    }
}