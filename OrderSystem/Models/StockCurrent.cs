using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Models
{
    public class StockCurrent
    {
        private List<StockDetails> curr_stock;

        public StockCurrent()
        {
            curr_stock = new List<StockDetails>();
        }

        public void AddStock(StockDetails newstock)
        {
            StockDetails ns = curr_stock.FirstOrDefault(p => p.ProductID.ToUpperInvariant() == newstock.ProductID.ToUpperInvariant());
            if (ns != null)
            {
                ns.Qty++;
            }
            else
            {
                curr_stock.Add(new StockDetails() { ProductID = ns.ProductID, Name = ns.Name, Price = ns.Price, Qty = ns.Qty });
            }
        }
    }
}
