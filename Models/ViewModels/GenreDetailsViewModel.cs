using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class GenreDetailsViewModel
    {
        public int GenreId { get; set; }
        public string Title { get; set; }
        public List<BookListViewModel> Books { get; set; }
        public int BookId { get; set; }

    }
}