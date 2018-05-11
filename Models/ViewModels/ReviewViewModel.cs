using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class ReviewViewModel
    {
        public double CartTotal { get; set; }
        public List<BookInCartViewModel> Books { get; set; }
    }
}