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

                var initialGenres = new List<Genre>()
                {
                    new Genre { Drama = "Titanic", Action = "Top Gun"},
                    new Genre { Drama = "Titanic", Action = "Top Gun"},
                    new Genre { Drama = "Titanic", Action = "Top Gun"}
                };
                db.AddRange(initialGenres);
                //db.SaveChanges();
        }
    }
}