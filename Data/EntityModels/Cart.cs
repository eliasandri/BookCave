using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace BookCave.Data.EntityModels
{
    public class Cart
    {
        private DataContext _db; 
        //private AuthenticationDbContext _adb;
        int ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public Cart()
        {
            _db = new DataContext();
        }

        public static Cart GetCart(int id)
        {
            
            var cart = new Cart();
            cart.ShoppingCartId = cart.GetCartId(id);
            return cart;
        }

        /*public static Cart GetCart(int id)
        {
            return GetCart(controller.HttpContext);
        }*/

        public void AddToCart(Book book)
        {
            Console.WriteLine(ShoppingCartId);
            var cartItem = _db.ShopCarts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ItemId == book.Id);

            if (cartItem == null)
            {
                
                cartItem = new ShopCart
                {
                    ItemId = book.Id,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                _db.ShopCarts.Add(cartItem);
            }
            else
            {
                
                cartItem.Count++;
            }
            
            _db.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            
            var cartItem = _db.ShopCarts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    _db.ShopCarts.Remove(cartItem);
                }
                
                _db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = _db.ShopCarts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                _db.ShopCarts.Remove(cartItem);
            }
            
            _db.SaveChanges();
        }
        public List<ShopCart> GetCartItems()
        {
            return _db.ShopCarts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }
        public int GetCount()
        {

            int? count = (from cartItems in _db.ShopCarts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public double GetTotal()
        {
            
            double total = (from cartItems in _db.ShopCarts
                              where cartItems.CartId == ShoppingCartId
                              select (int)cartItems.Count *
                              cartItems.Book.Price).Sum();

            return total;
        }

        public int CreateOrder(Order order)
        {
            double orderTotal = 0;

            var cartItems = GetCartItems();
            
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ItemId = item.ItemId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Book.Price,
                    Quantity = item.Count
                };
                
                orderTotal += (item.Count * item.Book.Price);

                _db.OrderDetails.Add(orderDetail);

            }
            
            order.Total = orderTotal;

            
            _db.SaveChanges();
            
            EmptyCart();
            
            return order.OrderId;
        }

        public int GetCartId(int id)
        {
            /*if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    
                    Guid tempCartId = Guid.NewGuid();
                    
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }*/
            return id;
        }

        /*public void MigrateCart(string Email)
        {
            var shoppingCart = _db.ShopCarts.Where(
                c => c.CartId == ShoppingCartId);

            foreach (ShopCart item in shoppingCart)
            {
                item.CartId = Email;
            }
            _db.SaveChanges();
        }*/
    }
}