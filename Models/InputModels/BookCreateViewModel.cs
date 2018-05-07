using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class BookCreateViewModel
    {
        public string Title { get; set; }

        [Required(ErrorMessage = "Must input Genre ID!")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Must input Price!")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Must input Rating!")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Must input Description!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Must input Release Year!")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Must input Author ID!")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Must input image link!")]
        public string Image { get; set; }
    }
}