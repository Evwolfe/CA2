using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Controllers
{
    public class StockController : Controller
    {
        private static List<StockDetails> stock
             = new List<StockDetails>()
             {
                new StockDetails() { ProductID = "CB001", Name = "Cadburys Dairy Milk", Price = 5.99, Qty = 50 },
                new StockDetails() { ProductID = "CB002", Name = "Cadburys Mint Crisp", Price = 4.99, Qty = 40 },
                new StockDetails() { ProductID = "CB003", Name = "Cadburys Wholenut", Price = 6.99, Qty = 50 },
                new StockDetails() { ProductID = "CB004", Name = "Cadburys Caramel", Price = 5.00, Qty = 30 }
             };

        // GET: StockController
        public ActionResult Index()
        {
            //ViewBag.TotalPrice = string.Format(cart.CalcTotal().ToString("C2"));
            return View(stock);
        }

        // GET: StockController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockController/Create
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

        // GET: StockController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockController/Edit/5
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

        // GET: StockController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockController/Delete/5
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

        /*private void SeedDB()
        {
            StockDetails s1 = new StockDetails() { ProductID = "CB001", Name = "Cadburys Dairy Milk", Price = 5.99, Qty = 50 };
            StockDetails s2 = new StockDetails() { ProductID = "CB002", Name = "Cadburys Mint Crisp", Price = 4.99, Qty = 40 };
            StockDetails s3 = new StockDetails() { ProductID = "CB003", Name = "Cadburys Wholenut", Price = 6.99, Qty = 50 };
            StockDetails s4 = new StockDetails() { ProductID = "CB004", Name = "Cadburys Caramel", Price = 5.00, Qty = 30 };

            Stock.Add(s1);
            Stock.Add(s2);
            Stock.Add(s3);
            Stock.Add(s4);

            Stock.SaveChanges();
        }*/
    }
}
