using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class WishListService
    {
        private WishListRepo _wishListRepo;
        public WishListService()
        {
            _wishListRepo = new WishListRepo();
        }
        public void AddToWishList(int id)
        {
            _wishListRepo.AddToWishList(id);
        }
        public WishListViewModel GetAllWishListItems()
        {
            var wishListItems = _wishListRepo.GetAllWishListItems();
            
            return wishListItems;
        }
    }
}