using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public double CartTotal { get; set; }
        public List<BookInCartViewModel> Books { get; set; }
    }
}