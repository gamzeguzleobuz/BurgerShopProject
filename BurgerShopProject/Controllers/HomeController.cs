using BurgerShopProject.Entities;
using BurgerShopProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BurgerShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Menus.OrderByDescending(x => x.Id).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Order()
        {
            var menus = _db.Menus.ToList(); // Menüleri veritabanından al
            //var order = new Order
            //{
            //    OrderPrice = 0,
            //    OrderPiece = 0, 
            //    Id = _db.Orders.Count() + 1,
            //    Customer = _db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name),
            //    Menus = menus,

            //};

            return View(menus);
        }
        [HttpPost]
        public IActionResult Order(Order order)
        {

            _db.Add(order);
            _db.SaveChanges();


            var orders = _db.Orders.Where(x => x.Customer.UserName == User.Identity.Name).ToList();
            return View(nameof(BurgerShopProject.OrdersController.Index), orders);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}