using BurgerShopProject.Entities;
using BurgerShopProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            ViewBag.Menus = _db.Menus.ToList();
            ViewBag.Extras = _db.Extras.ToList();
      
            var viewModel = new MenuExtraViewModel
            {
                Menu = _db.Menus.OrderByDescending(x => x.Id).ToList(),
                Extra = _db.Extras.OrderByDescending(x => x.Id).ToList()
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Order()
        {
            var menus = _db.Menus.ToList(); // Menüleri veritabanından al
            if (ModelState.IsValid)
            {
                return View(menus);
            }

            var extras = _db.Extras.ToList(); // Extraları veritabanından al
            if (ModelState.IsValid)
            {
                return View(extras);
            }
            //var order = new Order
            //{
            //    OrderPrice = 0,
            //    OrderPiece = 0, 
            //    Id = _db.Orders.Count() + 1,
            //    Customer = _db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name),
            //    Menus = menus,

            //};

            return View();
        }
        [HttpPost]
        public IActionResult Order(Order order)
        {
                order.Customer = _db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                order.OrderPrice = order.Menus.Sum(x => x.MenuPrice);
                _db.Add(order);
                _db.SaveChanges();


                var orders = _db.Orders.Where(x => x.Customer.UserName == User.Identity.Name).ToList();
            return RedirectToAction("Index", "Orders",orders);


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}