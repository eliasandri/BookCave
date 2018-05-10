namespace BookCave.Models.ViewModels
{
    public class OrderListViewModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public double BookPrice { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
    }
}