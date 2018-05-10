using System.Collections.Generic;
using BookCave.Data;
using BookCave.Data.EntityModels;

namespace BookCave.Repositories
{
    public class WishListRepo
    {
        private DataContext _db;
        public WishListRepo()
        {
            _db = new DataContext();
        }
        public void AddToWishList (int id)
        {
            
            var wishListItem = new WishList()
            {
                BookId = id,
            };
            _db.WishLists.Add(wishListItem);
            _db.SaveChanges();
        }
    }
}