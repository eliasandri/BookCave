using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class OrderController : Controller
    {
        private OrderService _orderService;
        

        public OrderController()
        {
            _orderService = new OrderService();
            
        }
        public IActionResult OrderHistory()
        {
            var orders = _orderService.GetAllUserOrders();
            return View(orders);
        }
    }
}