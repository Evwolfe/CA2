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
    public class OrderEntriesController : Controller
    {
        private readonly OrderContext _context;

        public OrderEntriesController()
        {
            _context = new OrderContext();
            _context.Database.EnsureCreated();
        }

        // GET: OrderEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderDetails.ToListAsync());
        }

        // GET: OrderEntries/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderEntry = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orderEntry == null)
            {
                return NotFound();
            }

            return View(orderEntry);
        }

        // GET: OrderEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,Address,DeliveryID")] OrderEntry orderEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderEntry);
        }

        // GET: OrderEntries/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderEntry = await _context.OrderDetails.FindAsync(id);
            if (orderEntry == null)
            {
                return NotFound();
            }
            return View(orderEntry);
        }

        // POST: OrderEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrderID,Address,DeliveryID")] OrderEntry orderEntry)
        {
            if (id != orderEntry.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderEntryExists(orderEntry.OrderID))
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
            return View(orderEntry);
        }

        // GET: OrderEntries/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderEntry = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orderEntry == null)
            {
                return NotFound();
            }

            return View(orderEntry);
        }

        // POST: OrderEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var orderEntry = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderEntryExists(string id)
        {
            return _context.OrderDetails.Any(e => e.OrderID == id);
        }
    }
}
