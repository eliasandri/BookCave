namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int BookId { get; set; }   

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public string Author { get; set; }
        
        public int AuthorId { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Rating { get; set; }

        public string Image { get; set; }

        public string Genre { get; set; }

        public int GenreId { get; set; }
    }
}