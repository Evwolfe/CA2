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
        private readonly StockContext _context;

        public StockController()
        {
            _context = new StockContext();
            _context.Database.EnsureCreated();
        }

        // GET: StockController
        public ActionResult Index()
        {
            return View();
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
    }
}
