using System.Collections.Generic;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using System.Linq;
using System;

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
        public WishListViewModel GetAllWishListItems()
        {
            var wishListItems = (from m in _db.WishLists
                                 join mr in _db.Books on m.BookId equals mr.Id
                                 select new WishListViewModel
                                 {
                                     Books = (from a in _db.Books
                                              join ar in _db.WishLists on a.Id equals ar.BookId
                                              
                                              select new BookInWishListViewModel()
                                              {
                                                 ReleaseYear = a.ReleaseYear,
                                                 Title = a.Title,
                                                 BookId = a.Id,
                                                 Image = a.Image,
                                                 Price = a.Price 
                                              }).ToList(),
                                 }).FirstOrDefault();
            return wishListItems;
        }
    }
}