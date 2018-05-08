using System;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DataContext _db = new DataContext();
        public IActionResult Index()
        {

            var cart = Cart.GetCart(2);
            //Console.WriteLine(id);
            
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            
            return View(viewModel);
        }
        
        public ActionResult AddToCart(int id)
        {
            
            var addedItem = _db.Books
                .Single(item => item.Id == id);

            Console.WriteLine(id);
            var cart = Cart.GetCart(id);

            cart.AddToCart(addedItem);

            
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            
            
            var cart = Cart.GetCart(id);

            
            string itemName = _db.ShopCarts
                .Single(item => item.RecordId == id).Book.Title;

            
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
        public ActionResult CartSummary(int id)
        {
            
            var cart = Cart.GetCart(id);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}