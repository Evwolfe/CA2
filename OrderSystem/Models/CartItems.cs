using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Models
{
    public class Items
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [DisplayName("Price (€): ")]
        public double Price { get; set; }
    }

    public class CartItems : Items
    {
        public int Qty { get; set; }
    }
}
