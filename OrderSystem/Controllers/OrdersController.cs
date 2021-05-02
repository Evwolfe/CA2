using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CA2_OrderSystem.Models;
using CA2_OrderSystem.Controllers;

namespace OrderSystem.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersContext _context;

        public OrdersController()
        {
            _context = new OrdersContext(); 
            _context.Database.EnsureCreated();
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderDetails.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
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

        /*
        public async Task<IActionResult> Create([Bind("ID,OrderID,Address,Details")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }
        */

        public async Task<IActionResult> Create(Orders orders)
        {
            if (ModelState.IsValid)
            {

                List<string> s1 = new List<string>();
                List<CartItems> c1 = CartController.c1.ReturnCart();
                foreach (CartItems xx in c1)
                {
                    s1.Add(xx.Name);
                }
                string s2 = string.Join(", ", s1);

                int ordID;
                if (_context.OrderDetails.Count() == 0)
                {
                    ordID = 1;
                }
                else
                {
                    ordID = _context.OrderDetails.Count() + 1;
                }

                _context.Add(new Orders { OrderID = ordID, Address = orders.Address, Details = s2 });

                await _context.SaveChangesAsync();
                CartController.c1.EmptyCart();

                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }





        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.OrderDetails.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OrderID,Address,Details")] Orders orders)
        {
            if (id != orders.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.ID))
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
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.OrderDetails.Any(e => e.ID == id);
        }
    }
}
