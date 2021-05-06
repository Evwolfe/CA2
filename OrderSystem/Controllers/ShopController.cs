using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CA2_OrderSystem.Models;

namespace CA2_OrderSystem.Controllers
{
    public class ShopController : Controller
    {
        private readonly StockContext _context;

        public ShopController()
        {
            _context = new StockContext();
            _context.Database.EnsureCreated();
        }

        public void ReduceStock(Stock enrty)
        {
            var xy = _context.Stock.Find(enrty.ProdID);
            if(xy != null)
            {
               
                if (xy.Qty <= 0)
                {
                    RedirectToAction("Index");
                }
                else
                {
                    xy.Qty--;
                }

                _context.SaveChanges();
            }
        }

        public void IncreaseStock(Stock enrty)
        {
            var maxQty = enrty.Qty;
            var xy = _context.Stock.Find(enrty.ProdID);
            if (xy.Qty == maxQty)
            {
                RedirectToAction("Index");
            }
            else
            {
                xy.Qty++;
            }
            _context.SaveChanges();
        }


        // GET: Shop
        public async Task<IActionResult> Index()
        {
            var Shop = await _context.Stock.ToListAsync();
            ViewBag.TotalPrice = String.Format(CartController.c1.CalcTotal().ToString("C2"));
            return View(Shop);
        }

        // GET: Shop/Details/5
        public async Task<IActionResult> Add(string code)
        {
            var Shop = await _context.Stock.ToListAsync();

            Stock itm = Shop.FirstOrDefault(i => i.ProdID.ToUpperInvariant() == code.ToUpperInvariant());
            if (itm != null)
            {
                CartController.c1.AddItem(itm);
                ReduceStock(itm);
            }

            
            return RedirectToAction("Index");
        }

        // GET: Shop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdID,Name,Qty,Price")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Shop/Edit/5
        public async Task<IActionResult> Edit(string code)
        {
            var Shop = await _context.Stock.ToListAsync();
            
            Stock itm = Shop.FirstOrDefault(i => i.ProdID.ToUpperInvariant() == code.ToUpperInvariant());
            if (itm != null)
            {
                CartController.c1.RemoveItem(itm);
                IncreaseStock(itm);
                 
            }
            
            return RedirectToAction("Index");
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProdID,Name,Qty,Price")] Stock stock)
        {
            if (id != stock.ProdID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.ProdID))
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
            return View(stock);
        }

        // GET: Shop/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .FirstOrDefaultAsync(m => m.ProdID == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stock = await _context.Stock.FindAsync(id);
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(string id)
        {
            return _context.Stock.Any(e => e.ProdID == id);
        }
    }
}
