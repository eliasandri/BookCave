namespace BookCave.Data.EntityModels
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BookId { get; set; }
    }
}