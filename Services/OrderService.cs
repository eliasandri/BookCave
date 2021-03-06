using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class OrderService
    {
        private OrderRepo _orderRepo;

        public OrderService()
        {
            _orderRepo = new OrderRepo();
        }
        public List<OrderListViewModel> GetAllUserOrders()
        {
            var orders = _orderRepo.GetAllUserOrders();
            return orders;
        }
    }
}