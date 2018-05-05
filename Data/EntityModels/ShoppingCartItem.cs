namespace BookCave.Data.EntityModels
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Book Book { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartID { get; set; }
    }
}