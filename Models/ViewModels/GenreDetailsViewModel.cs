using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class GenreDetailsViewModel
    {
        public int GenreId { get; set; }


        public string Title { get; set; }

        public List<Book> Books { get; set; }

        public int BookId { get; set; }

    }
}