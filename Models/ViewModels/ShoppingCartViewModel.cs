using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        //public List<ShopCart> CartItems { get; set; }
        public double CartTotal { get; set; }
        public List<BookInCartViewModel> Books { get; set; }
    }
}