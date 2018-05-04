using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class GenreListViewModel
    {
        public int GenreId { get; set; }
        
        public string Book { get; set; }
        
        public int BookId { get; set; }

        public string Title { get; set; }
       
    }
}