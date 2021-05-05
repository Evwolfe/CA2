using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CA2_OrderSystem.Models
{
    public class Stock
    {
        [Key]
        [DisplayName("Product ID")]
        public string ProdID { get; set; }
        public string Name { get; set; }
        [DisplayName("Quantity")]
        public int Qty { get; set; }
        [DisplayName("Price (€)")]
        public double Price { get; set; }
    }
}
