using System.Collections.Generic;
using BookCave.Data.EntityModels;
namespace BookCave.Models.ViewModels

{
    public class BookDetailsViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public int Price { get; set; }

        public int Rating { get; set; }

        public string Image { get; set; }
        public string Description { get; set; }

        public List<Author> Authors { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public int GenreId { get; set; }
    }
}