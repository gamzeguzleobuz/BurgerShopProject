using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerShopProject.Entities;
using BurgerShopProject.Models;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Drawing;

namespace BurgerShopProject
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public OrdersController(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Cart()
        {
            var ordersCartViewModelFromSession = HttpContext.Session.Get<OrdersCartViewModel>("cartItems");
            if (ordersCartViewModelFromSession != null)
            {
                ViewData["CartItemsCount"] = ordersCartViewModelFromSession.Menus.Count() + ordersCartViewModelFromSession.Extras.Count();
            }

            return View(ordersCartViewModelFromSession);
        }

        public IActionResult AddToCart(int? id)
        {
            if (id != null)
            {
                _userManager.GetUserId(HttpContext.User);
                //var user = await _userManager.GetUserAsync(HttpContext.User);
                var a = _context.Users.Count();
                var user = HttpContext.User.Identity?.Name;

                var menu = _context.Menus.Where(x => x.Id == id).FirstOrDefault();
                var users = _context.Users.ToList();
                var customer = users.Where(x => x.UserName == user).FirstOrDefault();


                if (customer == null)
                {

                    TempData["AlertMessage"] = "Müşteri bulunamadı. Oncelikle giris yapmaniz gerekiyor!";
                    return RedirectToAction("Index", "Home");

                }

                var order = new Order
                {
                    Menus = new List<Menu> { menu },
                    OrderPrice = 0,
                    OrderPiece = 0,
                    Id = _context.Orders.Count() + 1,
                    Customer = customer
                };


                customer.Orders.Add(order);
                List<Menu> menus = new List<Menu>();
                foreach (Order item in customer.Orders)
                {
                    menus.AddRange(item.Menus);
                }

                List<Extra> extras = new List<Extra>();

                foreach (Order item in customer.Orders)
                {
                    extras.AddRange(item.Extras);
                }

                //OrdersCartViewModel ordersCartViewModel;
                //var ordersCartViewModelFromSession = HttpContext.Session.Get<OrdersCartViewModel>("cartItems");
                //if (ordersCartViewModelFromSession == null)
                //{
                //    ordersCartViewModel = new OrdersCartViewModel
                //    {
                //        Customer = customer,
                //        Menus = menus,
                //        Extras = extras
                //    };
                //    HttpContext.Session.Set("cartItems", ordersCartViewModel);
                //    return View(ordersCartViewModel);

                //}
                //else
                //{
                //    ordersCartViewModelFromSession = ordersCartViewModelFromSession;
                //    ordersCartViewModelFromSession.Menus.AddRange(menus);
                //    ordersCartViewModelFromSession.Extras.AddRange(extras);
                //}
                //return View(ordersCartViewModelFromSession);

                //*********************************************************************************************************************


                var ordersCartViewModelFromSession = HttpContext.Session.Get<OrdersCartViewModel>("cartItems");

                if (ordersCartViewModelFromSession != null)
                {
                    var menu2 = ordersCartViewModelFromSession.Menus.Find(x => x.Id == menu.Id);

                    if (ordersCartViewModelFromSession.Menus.Contains(menu2))
                    {
                        menu2.Quantity++;
                    }
                    else
                    {
                        ordersCartViewModelFromSession.Menus.AddRange(menus);
                    }
                }

               

                if (ordersCartViewModelFromSession == null)
                {
                    ordersCartViewModelFromSession = new OrdersCartViewModel
                    {
                        Customer = customer,
                        Menus = menus,
                        Extras = extras
                    };
                }

                
               

                //*********************************************************************************************************************




                HttpContext.Session.Set("cartItems", ordersCartViewModelFromSession);



                ViewData["CartItemsCount"] = ordersCartViewModelFromSession.Menus.Count() + ordersCartViewModelFromSession.Extras.Count();

                //return RedirectToAction("Index", "Home", ordersCartViewModelFromSession);
                return View(ordersCartViewModelFromSession);
            }

            return RedirectToAction("Index", "Home");
        }




        [HttpPost]
        public IActionResult AddToCart(OrdersCartViewModel ordersCartViewModel)
        {

            if (ordersCartViewModel != null)
            {
                List<Order> orders = new List<Order>();
                Order o1 = new Order();
                var customer = ordersCartViewModel.Customer;
                o1.Customer = ordersCartViewModel.Customer;
                o1.Menus = ordersCartViewModel.Menus;
                o1.Extras = ordersCartViewModel.Extras;
                customer.Orders.Add(o1);
                orders.Add(o1);
                _context.Add(o1);
                _context.SaveChanges();
                return View(orders);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ExtraAddToCart(int? id)
        {
            if (id != null)
            {
                _userManager.GetUserId(HttpContext.User);
                //var user = await _userManager.GetUserAsync(HttpContext.User);
                var a = _context.Users.Count();
                var user = HttpContext.User.Identity?.Name;

                var extra = _context.Extras.Where(x => x.Id == id).FirstOrDefault();
                var users = _context.Users.ToList();
                var customer = users.Where(x => x.UserName == user).FirstOrDefault();


                if (customer == null)
                    return NotFound();

                var order = new Order
                {
                    //Menus = new List<Menu>,
                    Extras = new List<Extra> { extra },
                    OrderPrice = 0,
                    OrderPiece = 0,
                    Id = _context.Orders.Count() + 1,
                    Customer = customer
                };


                customer.Orders.Add(order);
                List<Menu> menus = new List<Menu>();
                foreach (Order item in customer.Orders)
                {
                    menus.AddRange(item.Menus);
                }

                List<Extra> extras = new List<Extra>();

                foreach (Order item in customer.Orders)
                {
                    extras.AddRange(item.Extras);
                }


                //*********************************************************************************************************************

                var ordersCartViewModelFromSession = HttpContext.Session.Get<OrdersCartViewModel>("cartItems");

                if (ordersCartViewModelFromSession != null)
                {
                    var extra2 = ordersCartViewModelFromSession.Extras.Find(x => x.Id == extra.Id);

                    if (ordersCartViewModelFromSession.Extras.Contains(extra2))
                    {
                        extra2.Quantity++;
                    }
                    else
                    {
                        ordersCartViewModelFromSession.Extras.AddRange(extras);
                    }
                }

                if (ordersCartViewModelFromSession == null)
                {
                    ordersCartViewModelFromSession = new OrdersCartViewModel
                    {
                        Customer = customer,
                        Menus = menus,
                        Extras = extras
                    };
                }


                //*********************************************************************************************************************




                HttpContext.Session.Set("cartItems", ordersCartViewModelFromSession);
                //ViewBag.CartItems = ordersCartViewModelFromSession.Menus.Count() + ordersCartViewModelFromSession.Extras.Count();

                ViewData["CartItemsCount"] = ordersCartViewModelFromSession.Menus.Count() + ordersCartViewModelFromSession.Extras.Count();


                //return RedirectToAction("Index", "Home", ordersCartViewModelFromSession);
                return View("AddToCart", ordersCartViewModelFromSession);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult ExtraAddToCart(OrdersCartViewModel ordersCartViewModel)
        {
            List<Order> orders = new List<Order>();
            Order o1 = new Order();
            var customer = ordersCartViewModel.Customer;
            o1.Customer = ordersCartViewModel.Customer;
            o1.Menus = ordersCartViewModel.Menus;
            o1.Extras = ordersCartViewModel.Extras;
            customer.Orders.Add(o1);
            orders.Add(o1);
            _context.Add(o1);
            _context.SaveChanges();

            return View(orders);
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return _context.Orders != null ?
                        View(await _context.Orders.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderPiece,OrderPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderPiece,OrderPrice")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value, JsonSerializerOptions options = null)
        {
            options ??= new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            session.SetString(key, JsonSerializer.Serialize(value, options));
        }

        public static T Get<T>(this ISession session, string key, JsonSerializerOptions options = null)
        {
            var value = session.GetString(key);
            if (value == null)
            {
                return default;
            }

            options ??= new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            return JsonSerializer.Deserialize<T>(value, options);
        }
    }
}
