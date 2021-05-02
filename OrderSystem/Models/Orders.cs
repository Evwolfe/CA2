using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CA2_OrderSystem.Models
{
    public class Orders
    {
        [Key]
        [DisplayName("Order ID: ")]
        public string OrderID { get; set; }
        public string Address { get; set; }
        [DisplayName("Order Details: ")]
        public string Details { get; set; }

    }
}
