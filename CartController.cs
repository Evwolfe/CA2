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
    public class CartController : Controller
    { 
        private readonly CartContext _context;

        public CartController()
        {
            _context = new CartContext();
            _context.Database.EnsureCreated();
        }
        // GET: CartDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: CartDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartDetails = await _context.Items
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (cartDetails == null)
            {
                return NotFound();
            }

            return View(cartDetails);
        }

        // GET: CartDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Qty,Price")] StockDetails cartDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartDetails);
        }

        // GET: CartDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CartDetails = await _context.Items.FindAsync(id);
            if (CartDetails == null)
            {
                return NotFound();
            }
            return View(CartDetails);
        }

        // POST: CartDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProductID,Name,Qty,Price")] StockDetails cartDetails)
        {
            if (id != cartDetails.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartDetailsExists(cartDetails.ProductID))
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
            return View(cartDetails);
        }

        // GET: CartDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartDetails = await _context.Items
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (cartDetails == null)
            {
                return NotFound();
            }

            return View(cartDetails);
        }

        // POST: CartDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cartDetails = await _context.Items.FindAsync(id);
            _context.Items.Remove(cartDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartDetailsExists(string id)
        {
            return _context.Items.Any(e => e.ProductID == id);
        }
    }
}