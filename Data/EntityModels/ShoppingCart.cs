using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BookCave.Data.EntityModels
{
    public class ShoppingCart
    {
        private readonly DataContext _db;

        private ShoppingCart (DataContext db)
        {
            _db = db;
        }
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        
    }
}