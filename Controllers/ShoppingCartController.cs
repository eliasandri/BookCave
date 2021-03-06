using System;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookCave.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private DataContext _db = new DataContext();
        private readonly UserManager<ApplicationUser> _userManager;
        public ShoppingCartController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async System.Threading.Tasks.Task<IActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = Cart.GetCart(user.Id);

            /*var _books = (from m in _db.Books
                          where cart.G)*/

            var viewModel = new ShoppingCartViewModel
            {
                Books = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
                //Books = addedItem * cartItem.Count
            };
            return View(viewModel);
        }

        public async System.Threading.Tasks.Task<ActionResult> AddToCartAsync(int id)
        {
            var addedItem = _db.Books
                .Single(item => item.Id == id);

            var user = await _userManager.GetUserAsync(User);
            var cart = Cart.GetCart(user.Id);
            cart.AddToCart(addedItem);

            return RedirectToAction("IndexAsync");
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> RemoveFromCartAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = Cart.GetCart(user.Id);

            /*string itemName = _db.ShopCarts
                .Single(item => item.RecordId == id).Book.Title;*/

            int itemCount = cart.RemoveFromCart(id);

            var results = new ShoppingCartRemoveViewModel
            {
                /*Message = Server.HtmlEncode(itemName) +
                    " has been removed from your shopping cart.",*/
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        //[ChildActionOnly]
        public async System.Threading.Tasks.Task<ActionResult> CartSummaryAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = Cart.GetCart(user.Id);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
        public async System.Threading.Tasks.Task<IActionResult> Review()
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = Cart.GetCart(user.Id);

            /*var _books = (from m in _db.Books
                          where cart.G)*/

            var viewModel = new ReviewViewModel
            {
                Books = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
                //Books = addedItem * cartItem.Count
            };
            return View(viewModel);
        }
    }
}