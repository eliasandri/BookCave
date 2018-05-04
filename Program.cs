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
                    new Book { Title = "Charlie and the Chocolate Factory", Description = "Willy Wonka's famous chocolate factory is opening at last! But only five lucky children will be allowed inside. And the winners are: Augustus Gloop, an enormously fat boy whose hobby is eating; Veruca Salt, a spoiled-rotten brat whose parents are wrapped around her little finger; Violet Beauregarde, a dim-witted gum-chewer with the fastest jaws around; Mike Teavee, a toy pistol-toting gangster-in-training who is obsessed with television; and Charlie Bucket, Our Hero, a boy who is honest and kind, brave and true, and good and ready for the wildest time of his life!", Price = 10, Rating = 9, ReleaseYear = 2007, Image = "", AuthorId = 2 },
                };
                db.AddRange(initialBooks);
                db.SaveChanges();

                var initialArtists = new List<Author>()
                {
                    new Author { Name = "Roald Dahl", DateOfBirth = "13 September 1916", Image = "", BookId = 2 }
                };
                db.AddRange(initialArtists);
                db.SaveChanges();
        }
    }
}