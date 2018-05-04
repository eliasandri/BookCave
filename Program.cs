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
                    new Book { Title = "A Storm of Swords: Part 1 Steel and Snow", Description = "The future of the Seven Kingdoms hangs in the balance.In King's Landing the Queen Regent, Cersei Lannister, awaits trial, abandoned by all those she trusted; while in the eastern city of Yunkai her brother Tyrion has been sold as a slave. From the Wall, having left his wife and the Red Priestess Melisandre under the protection of Jon Snow, Stannis Baratheon marches south to confront the Boltons at Winterfell. But beyond the Wall the wildling armies are massing for an assault...On all sides bitter conflicts are reigniting, played out by a grand cast of outlaws and priests, soldiers and skinchangers, nobles and slaves. The tides of destiny will inevitably lead to the greatest dance of all.", Price = 9, Rating = 8, ReleaseYear = 2000, Image = "", AuthorId = 8 },
                };
                db.AddRange(initialBooks);
                db.SaveChanges();

               /*var initialArtists = new List<Author>()
                {
                    new Author { Name = "George R.R. Martin", DateOfBirth = "20 September 1948", Image = "", BookId = 10 }
                };
                db.AddRange(initialArtists);
                db.SaveChanges(); */
        }
    }
}