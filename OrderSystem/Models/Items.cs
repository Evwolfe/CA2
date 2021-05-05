using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CA2_OrderSystem.Models
{
    public class Items
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        [DisplayName("Price (€)")]
        public double Price { get; set; }
    }


    public class CartItems : Items
    {
        public int Qty { get; set; }
    }

}
