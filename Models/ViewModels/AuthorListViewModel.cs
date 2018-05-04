using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class AuthorListViewModel
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Image { get; set; }
        public string Book { get; set; }
        public int BookId { get; set; }

    }
}