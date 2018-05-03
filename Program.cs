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

                var initialAuthors = new List<Author>()
                {
                    new Author { Name = "War and Peace",DateOfBirth = "22 mars 1954" },
                    new Author { Name = "The Adventures of Huckleberry Finn", DateOfBirth = "2 april 1970" },
                    new Author { Name = "Moby-Dick", DateOfBirth = "30 desember 1945" }
                };
                db.AddRange(initialAuthors);
                db.SaveChanges();
        }
    }
}