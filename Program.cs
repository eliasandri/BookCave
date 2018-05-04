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
                    new Book { Title = "Developing Fraction Knowledge", Description ="Supporting and understanding your students' fractional knowledge is crucial to their overall grasp of numbers and mathematics. By centralizing around three key stages of development, this effective guide will help you to assess your students' understanding of fractions and modify your teaching accordingly." , Price = 12, Rating = 7, ReleaseYear = 2016, Image = "", AuthorId = 19 },
                };
                db.AddRange(initialBooks);
                db.SaveChanges();

               var initialArtists = new List<Author>()
                {
                    new Author { Name = "Amy J Hackenber", DateOfBirth = "", Image = "", BookId = 25 }
                };
                db.AddRange(initialArtists);
                db.SaveChanges(); 
        }
    }
}