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
            var orders = (from m in _db.OrderDetails
                        join mr in _db.Orders on m.OrderId equals mr.OrderId
                        select new OrderListViewModel
                        {
                            BookId = m.ItemId,
                            Count = m.Quantity,
                            BookPrice = m.UnitPrice,
                            OrderId = m.OrderId,
                            Books = (from b in _db.Books
                            join br in _db.OrderDetails on b.Id equals br.ItemId
                            where b.Id == br.ItemId
                            select new BookInOrderViewModel
                            {
                                BookId = b.Id,
                                BookTitle = b.Title,
                                BookPrice = b.Price,
                            }).ToList()
                        }).ToList();
            
        Console.WriteLine(orders[0].Books[2].BookTitle);
        return orders;
        }
    }
}