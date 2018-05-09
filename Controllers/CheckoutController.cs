using System;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private DataContext _db = new DataContext();
        const string PromoCode = "FREE";

        private readonly UserManager<ApplicationUser> _userManager;
        public CheckoutController (UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> AddressAndPaymentAsync(OrderCreateViewModel _order)
        {
            Console.WriteLine();
            var order = new Order();
            await TryUpdateModelAsync(order);

            try
            {
                if (_order.PromoCode != 50)
                {
                    
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    
                    _db.Orders.Add(order);
                    _db.SaveChanges();
                    
                    var user = await _userManager.GetUserAsync(User);
                    var cart = Cart.GetCart(user.Id);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }
            catch
            {
                
                return RedirectToAction("Complete",
                        new { id = order.OrderId });
            }
        }
        
        public ActionResult Complete(int id)
        {
            
            bool isValid = _db.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}