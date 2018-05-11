using BookCave.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        private WishListService _wishListService;

        public WishListController()
        {
            _wishListService = new WishListService();
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
        public IActionResult AllWishListItems()
        {
            var wishListItems = _wishListService.GetAllWishListItems();
            return View(wishListItems);
        }
    }
}