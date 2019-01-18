using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eshopper.Data;
using eshopper.Models;

namespace eshopper.Controllers
{
    public class HomeProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HomeProduct
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeProducts.ToListAsync());
        }

        // GET: HomeProduct/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeProducts = await _context.HomeProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeProducts == null)
            {
                return NotFound();
            }

            return View(homeProducts);
        }

        // GET: HomeProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Photo")] HomeProducts homeProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeProducts);
        }

        // GET: HomeProduct/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeProducts = await _context.HomeProducts.FindAsync(id);
            if (homeProducts == null)
            {
                return NotFound();
            }
            return View(homeProducts);
        }

        // POST: HomeProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Price,Photo")] HomeProducts homeProducts)
        {
            if (id != homeProducts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeProductsExists(homeProducts.Id))
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
            return View(homeProducts);
        }

        // GET: HomeProduct/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeProducts = await _context.HomeProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeProducts == null)
            {
                return NotFound();
            }

            return View(homeProducts);
        }

        // POST: HomeProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var homeProducts = await _context.HomeProducts.FindAsync(id);
            _context.HomeProducts.Remove(homeProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeProductsExists(string id)
        {
            return _context.HomeProducts.Any(e => e.Id == id);
        }
    }
}
