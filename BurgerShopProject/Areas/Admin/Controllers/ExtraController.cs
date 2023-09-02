using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BurgerShopProject.Entities;
using BurgerShopProject.Areas.Admin.Models;

namespace BurgerShopProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExtraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExtraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Extra
        public async Task<IActionResult> Index()
        {
              return _context.Extras != null ? 
                          View(await _context.Extras.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Extras'  is null.");
        }

        // GET: Admin/Extra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Extras == null)
            {
                return NotFound();
            }

            var extras = await _context.Extras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extras == null)
            {
                return NotFound();
            }

            return View(extras);
        }

        // GET: Admin/Extra/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Extra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExtraName,ExtraPrice,ExtraImageName")] ExtraViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var menu = new Extra();
                menu.ExtraName = vm.ExtraName;
                menu.ExtraPrice = vm.ExtraPrice;

                if (vm.ExtraImageName != null)
                {
                    var fileName = vm.ExtraImageName.FileName;
                    menu.ExtraImageName = fileName;
                    string fmName = Guid.NewGuid().ToString() + fileName;
                    var route = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    var flowArea = new FileStream(route, FileMode.Create);
                    vm.ExtraImageName.CopyTo(flowArea);
                    flowArea.Close();
                }
                _context.Extras.Add(menu);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Admin/Extra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Extras == null)
            {
                return NotFound();
            }

            var extras = await _context.Extras.FindAsync(id);
            if (extras == null)
            {
                return NotFound();
            }
            return View(extras);
        }

        // POST: Admin/Extra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExtraName,ExtraPrice,ExtraImageName")] Extra extras)
        {
            if (id != extras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtrasExists(extras.Id))
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
            return View(extras);
        }

        // GET: Admin/Extra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Extras == null)
            {
                return NotFound();
            }

            var extras = await _context.Extras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extras == null)
            {
                return NotFound();
            }

            return View(extras);
        }

        // POST: Admin/Extra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Extras == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Extras'  is null.");
            }
            var extras = await _context.Extras.FindAsync(id);
            if (extras != null)
            {
                _context.Extras.Remove(extras);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtrasExists(int id)
        {
          return (_context.Extras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
