using BookCave.Models.ViewModels;

namespace BookCave.Models.ViewModels
{
    public class BookNewest5ViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Image { get; set; }
    }
}