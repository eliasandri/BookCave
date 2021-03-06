using System.Collections.Generic;
namespace BookCave.Models.ViewModels

{
    public class BookDetailsViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public double Price { get; set; }

        public int Rating { get; set; }

        public string Image { get; set; }
        public string Description { get; set; }
        public int Ratings { get; set; }
        public List<AuthorListViewModel> Authors { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public int GenreId { get; set; }
        public string Review { get; set; }
       
        public List<CommentViewModel> Reviews { get; set; }
        public double AverageRating { get; set; }

    }
}