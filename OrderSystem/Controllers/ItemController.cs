using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Controllers
{
    public class ItemController : StockDetailsController
    {
        private readonly CartContext _context;

        public ItemController()
        {
            _context = new CartContext();
            _context.Database.EnsureCreated();
        }

        private static Cart cart = new Cart();

        // GET: OrderController
        public ActionResult ItemsIndex()
        {
            ViewBag.TotalPrice = cart.CalcTotal();
            return View(_context.Items);
        }

        // GET: OrderController/Details/5
        public ActionResult Add(string code)
        {
            Items itm = _context.Items.FirstOrDefault(x => x.Name == code);
            if (itm != null)
            {
                cart.AddItem(itm);
            }
            return RedirectToAction("Index");
        }

    }
}
