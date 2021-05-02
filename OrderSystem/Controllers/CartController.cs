using CA2_OrderSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA2_OrderSystem.Controllers
{
    public class CartController : Controller
    {

        public static Cart c1 = new Cart();
        
        private readonly StockContext _context;
        
        public CartController()
        {
            
            _context = new StockContext();
            _context.Database.EnsureCreated();
        }

        public Cart ReturnCart()
        {
            return c1;
        }

        // GET: CartController
        public ActionResult Index()
        {
            
            ViewBag.TotalPrice = String.Format(CartController.c1.CalcTotal().ToString("C2"));
            return View(c1);
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5

        public async Task<IActionResult> Edit(string code)
        {
            var Shop = await _context.Stock.ToListAsync();

            Stock itm = Shop.FirstOrDefault(i => i.ProdID.ToUpperInvariant() == code.ToUpperInvariant());
            if (itm != null)
            {
                c1.RemoveItem(itm);
                
            }

            return RedirectToAction("Index");
        }
        
        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
