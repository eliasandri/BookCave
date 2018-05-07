namespace BookCave.Data.EntityModels
{
    public class Book
    {
        public int Id { get; set; }   
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public int ReleaseYear { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
    }
}