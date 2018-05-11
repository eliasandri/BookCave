using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private AdminService _adminService;
        public AdminController()
        {
            _adminService = new AdminService();
        }
        public IActionResult Index()
        {
            var books = _adminService.GetAllBooks();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookCreateViewModel book)
        {
            if (ModelState.IsValid)
            {
                _adminService.CreateBook(book);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            //int? _id = id;
            var book = _adminService.GetBookWithId(id);
            //var db = new DataContext();
            //Book book = db.Books.Single(model => model.Id == id);

            if (book == null)
            {
                return View("Error");
            }
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(BookDetailsViewModel book)
        {
            if (ModelState.IsValid)
            {
                /*var db = new DataContext();
                db.Books.Update(book);
                db.SaveChanges();*/
                _adminService.EditBook(book);

                return RedirectToAction("Index");
            }
            return View("Book");
        }
    }
}