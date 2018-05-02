namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int BookId { get; set; }   

        public string Name { get; set; }

        public int ReleaseYear { get; set; }

        public string Author { get; set; }
        
        public int AuthorId { get; set; }
    }
}