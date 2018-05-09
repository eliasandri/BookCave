namespace BookCave.Data.EntityModels

{
    public class Comment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Review { get; set; }
    }
}