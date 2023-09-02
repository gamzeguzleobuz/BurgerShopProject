using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerShopProject.Entities;
using System.ComponentModel.DataAnnotations;
using BurgerShopProject.Areas.Admin.Models;
using System.Drawing;

namespace BurgerShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Menu
        public async Task<IActionResult> Index()
        {
            return _context.Menus != null ?
                        View(await _context.Menus.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Menus'  is null.");
        }

        // GET: Admin/Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Admin/Menu/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MenuName,MenuPrice,MenuSize,MenuImageName")] MenuViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var size = vm.MenuSize;
                var menu = new Menu();
                menu.MenuName = vm.MenuName;
                menu.MenuPrice = vm.MenuPrice;
                menu.MenuSize = vm.MenuSize; // Enum değeri atama

                if (vm.MenuImageName != null)
                {
                    var fileName = vm.MenuImageName.FileName;
                    menu.MenuImageName = fileName;
                    string fmName = Guid.NewGuid().ToString() + fileName;
                    var route = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    var flowArea = new FileStream(route, FileMode.Create);
                    vm.MenuImageName.CopyTo(flowArea);
                    flowArea.Close();
                }
                _context.Menus.Add(menu);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Admin/Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Admin/Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MenuName,MenuPrice,MenuSize,MenuImageName")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            return View(menu);
        }

        // GET: Admin/Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Menus == null)
            {
                return View();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Admin/Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Menus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Menus'  is null.");
            }
            var menu = await _context.Menus.FindAsync(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return (_context.Menus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
