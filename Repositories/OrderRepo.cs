using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Linq;
using System;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private DataContext _db;
        public OrderRepo()
        {
            _db = new DataContext();
        }
        public List<OrderListViewModel> GetAllUserOrders()
        {
            var _bookRepo = new BookRepo();

            var orders = (from m in _db.OrderDetails
                          join mr in _db.Orders on m.OrderId equals mr.OrderId
                          select new OrderListViewModel
                          {
                              BookId = m.ItemId,
                              Count = m.Quantity,
                              BookPrice = m.UnitPrice,
                              OrderId = m.OrderId,
                              Books = _bookRepo.GetBooksInUserOrder()
                          }).ToList();
            return orders;
        }

    }
}