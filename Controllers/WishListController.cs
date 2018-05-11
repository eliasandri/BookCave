using System.Collections.Generic;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookCave.Data;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        private WishListService _wishListService;
        private readonly UserManager<ApplicationUser> _userManager;
        private DataContext _db; 

        public WishListController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _wishListService = new WishListService();
            _db  = new DataContext();
            
        }
        public IActionResult AddToWishList(int id)
        {
            string _id = id.ToString();
            if (_id == null)
            {
                return View("Error");
            }
            _wishListService.AddToWishList(id);
            return RedirectToAction("AllWishListItems");
        }
        public async System.Threading.Tasks.Task<IActionResult> AllWishListItemsAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var wishListItems = _wishListService.GetAllWishListItems();
            wishListItems.Books = (from m in _db.Books
                             join mr in _db.WishLists on m.Id equals mr.BookId
                             where mr.UserId == user.Id
                             select new BookInWishListViewModel
                             {
                                 ReleaseYear = m.ReleaseYear,
                                                 Title = m.Title,
                                                 BookId = m.Id,
                                                 Image = m.Image,
                                                 Price = m.Price 
                             }).ToList();
            
            return View(wishListItems);
        }
    }
}