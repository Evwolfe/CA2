using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;

namespace OrderSystem.Controllers
{
    public class StockDetailsController : Controller
    {
        private readonly StockContext _context;

        public StockDetailsController()
        {
            _context = new StockContext();
            _context.Database.EnsureCreated();
        }

        // GET: StockDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stock.ToListAsync());
        }

        // GET: StockDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockDetails = await _context.Stock
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (stockDetails == null)
            {
                return NotFound();
            }

            return View(stockDetails);
        }

        // GET: StockDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Qty,Price")] StockDetails stockDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockDetails);
        }

        // GET: StockDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockDetails = await _context.Stock.FindAsync(id);
            if (stockDetails == null)
            {
                return NotFound();
            }
            return View(stockDetails);
        }

        // POST: StockDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProductID,Name,Qty,Price")] StockDetails stockDetails)
        {
            if (id != stockDetails.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockDetailsExists(stockDetails.ProductID))
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
            return View(stockDetails);
        }

        // GET: StockDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockDetails = await _context.Stock
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (stockDetails == null)
            {
                return NotFound();
            }

            return View(stockDetails);
        }

        // POST: StockDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stockDetails = await _context.Stock.FindAsync(id);
            _context.Stock.Remove(stockDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockDetailsExists(string id)
        {
            return _context.Stock.Any(e => e.ProductID == id);
        }
    }
}
