using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Models
{
    public class OrderEntry
    {
        [Key]
        public string OrderID { get; set; }
        public string Address { get; set; }
        public string DeliveryID { get; set; }

        private List<Cart> order;

        public newEntry()
        {
            order = new List<Cart>();
        }
        public double CalcTotal()
        {
            return newEntry.Sum(p => p.Price * p.Qty);
        }
    }
}
