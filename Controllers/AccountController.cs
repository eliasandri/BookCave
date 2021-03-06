using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using BookCave.Services;
using BookCave.Data.EntityModels;
using System;

namespace BookCave.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> RoleManager;
        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            RoleManager = roleManager;
        }
        private async Task MigrateShoppingCartAsync(string email)
        {
            var user = await _userManager.GetUserAsync(User);
            Console.WriteLine(user.Id);
            var cart = Cart.GetCart(user.Id);
            cart.MigrateCart(email);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) { return View(); }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));
                await _signInManager.SignInAsync(user, isPersistent: false);
                MigrateShoppingCartAsync(model.Email);
                //The user is successfully registered
                //Add the concatenated first and last name as fullName in claims

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) { return View(); }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                MigrateShoppingCartAsync(model.Email);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Basket()
        {
            return View();
        }

        public IActionResult WishList()
        {
            return View();
        }

        public IActionResult ShippingAndPay()
        {
            return View();
        }
        public IActionResult OrderHistory()
        {
            return View();
        }


        [Authorize]

        public async Task<IActionResult> MySite()
        {


            var user = await _userManager.GetUserAsync(User);
            var model = new MySiteViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                FavoriteBook = user.FavoriteBook
            };
            return View(model);
        }
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(new AccountDetailsViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FavoriteBook = user.FavoriteBook,
                Address = user.Address
            });
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile(AccountDetailsViewModel model)
        {

            var user = await _userManager.GetUserAsync(User);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;
            user.FavoriteBook = model.FavoriteBook;

            await _userManager.UpdateAsync(user);

            return View(model);
        }
    }
}