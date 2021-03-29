using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Models
{
    public class StockDetails
    {
        [Key]
        public string ProductID { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        [DisplayName("Price (€): ")]
        public double Price { get; set; }
    }
}
