namespace BookCave.Data.EntityModels
{
    public class Book
    {
        public int Id { get; set; }   
        
        public string Name { get; set; }

        public int ReleaseYear { get; set; }

        public int AuthorId { get; set; }
         
    }
}