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
            seedData(); 
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void seedData()
        {
            var db = new DataContext();

            if(!db.Books.Any() )
            {
                var initialBooks = new List<Book>()
                {
                new Book { Name = "War and Peace", ReleaseYear = 1990, AuthorId = 1 },
                new Book { Name = "The Adventures of Huckleberry Finn", ReleaseYear = 1985, AuthorId = 2 },
                new Book { Name = "Moby-Dick", ReleaseYear = 2002, AuthorId = 3 }
                };
                db.AddRange(initialBooks);
                db.SaveChanges();
            }
        }
    }
}