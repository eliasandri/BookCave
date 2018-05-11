namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int AuthorId { get; set; }

        public double Price { get; set; }

        public int Rating { get; set; }

        public string Image { get; set; }

    }
}