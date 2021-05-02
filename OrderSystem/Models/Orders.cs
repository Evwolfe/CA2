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
        public int ID { get; set; }

        [DisplayName("Order ID: ")]
        public int OrderID { get; set; }
        public string Address { get; set; }
        [DisplayName("Order Details: ")]
        public string Details { get; set; }

    }
}
