using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class OrderListViewModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public double BookPrice { get; set; } //taka út þetta þv´þetta í books
        public int Count { get; set; }
        public int OrderId { get; set; }
        public List<BookInOrderViewModel> Books { get; set; }

    }
}