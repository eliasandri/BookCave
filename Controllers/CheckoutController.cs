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
        public CheckoutController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult AddressAndPaymentAsync()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> AddressAndPaymentAsync(OrderCreateViewModel _order)
        {
            var user = await _userManager.GetUserAsync(User);
            var cart = Cart.GetCart(user.Id);

            double totalCartPrice = cart.GetTotal();

            var order = new Order()
            {
                FirstName = _order.FirstName,
                LastName = _order.LastName,
                Address = _order.Address,
                City = _order.City,
                State = _order.State,
                PostalCode = _order.PostalCode,
                Country = _order.Country,
                Phone = _order.Phone,
                Email = _order.Email,
                Total = totalCartPrice,
            };

            //await TryUpdateModelAsync(order);

            /*if (_order.PromoCode != 50)
            {

                return View(order);
            }*/
            if (ModelState.IsValid)
            {
                Console.WriteLine("damn");
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;

                Console.WriteLine(order.Username);
                _db.Orders.Add(order);
                _db.SaveChanges();


                cart.CreateOrder(order);

                return RedirectToAction("Complete",
                    new { id = order.OrderId });
            }
            return View();
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