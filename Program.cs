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

                  

                    new Book { Title = "The Fault in Our Stars", Description ="Despite the tumor-shrinking medical miracle that has bought her a few years, Hazel has never been anything but terminal, her final chapter inscribed upon diagnosis. But when a gorgeous plot twist named Augustus Waters suddenly appears at Cancer Kid Support Group, Hazel's story is about to be completely rewritten. Insightful, bold, irreverent, and raw, `The Fault in Our Stars` is award-winning author John Green's most ambitious and heartbreaking work yet, brilliantly exploring the funny, thrilling, and tragic business of being alive and in love. This book comes from the `New York Times` bestselling author of `Looking for Alaska`, `An Abundance of Katherines`, `Paper Towns` and - with David Levithan - Will Grayson, Will Grayson. John Green has over 1.2 million Twitter followers, and almost 700,000 subscribers to Vlogbrothers, the YouTube channel he created with his brother, Hank. `The Fault in Our Stars` will capture a crossover audience in the same vein as Zadie Smith, David Nicholls' `One Day` and `Before I Die` by Jenny Downham. `Electric ...Filled with staccato bursts of humor and tragedy.` (`Jodi Picoult`)." , Price = 14, Rating = 10, ReleaseYear = 2014, Image = "https://images-na.ssl-images-amazon.com/images/I/51gnhI6hYdL._SX335_BO1,204,203,200_.jpg", AuthorId = 23 },
 
                };
                db.AddRange(initialBooks);
                db.SaveChanges();

               var initialArtists = new List<Author>()
                {

                    new Author { Name = "John Green", DateOfBirth = "24 August 1977", Image = "https://pmcvariety.files.wordpress.com/2015/07/john-green-first-look-deal-fox.jpg?w=700&h=394&crop=1", BookId = 29 }
                };
                db.AddRange(initialArtists);
                db.SaveChanges();  

                var initialGenres = new List<Genre>()
                {
                    new Genre { Title = "Drama", BookId = 1}
                };
                db.AddRange(initialGenres);
                db.SaveChanges();
        }
    }
}