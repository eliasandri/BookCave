using BookCave.Models.ViewModels;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookTop5ViewModel
    {
        public int BookId {get; set; }
        public string Title {get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }
        public List<BookNewest5ViewModel> GetNewest5Books { get; set; }
        
    }
}