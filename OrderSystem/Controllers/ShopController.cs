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
    public class ShopController : StockDetailsController
    {
        private readonly CartContext _context;

        public ShopController()
        {
            _context = new CartContext();
            _context.Database.EnsureCreated();
        }

        private static List<CartItems> StockList = new List<CartItems>();
        //foreach (Items i in Db.Stock)

        private static Cart cart = new Cart();


        // GET: OrderController
        public ActionResult CartIndex()
        {
            ViewBag.TotalPrice = String.Format(cart.CalcTotal().ToString("C2"));
            return View(StockList);
        }

        // GET: OrderController/Details/5
        public ActionResult Add(string code)

        {
 
            Items itm = StockList.FirstOrDefault(x => x.Name == code);
            if (itm != null)
            {
                cart.AddItem(itm);
            }
            return RedirectToAction("Index");
        }

    }
}
