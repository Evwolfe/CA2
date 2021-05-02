using CA2_OrderSystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CA2_OrderSystem.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        public List<CartItems> items;
        
        public Cart()
        {
            items = new List<CartItems>();
        }

        public void AddItem(Stock choice)
        {
            CartItems found = items.FirstOrDefault(p => p.ID.ToUpperInvariant() == choice.ProdID.ToUpperInvariant());
            if (found != null)
            {
                found.Qty++;
            }
            else
            {
                items.Add(new CartItems() { ID = choice.ProdID, Name = choice.Name, Price = choice.Price, Qty = 1 });
            }
            
           
        }

        public List<CartItems> ReturnCart()
        {
            return items;
        }

        public double CalcTotal()
        {
            return items.Sum(p => p.Price * p.Qty);
        }

        public void RemoveItem(Stock choice)
        {

            CartItems found = items.FirstOrDefault(p => p.ID == choice.ProdID);
            if (found != null)
            {
                found.Qty--;
                if (found.Qty <= 0)
                {
                    items.Remove(found);
                }
            }
            
        }
        
        public void EditItems(CartItems choice)
        {
            CartItems found = items.FirstOrDefault(p => p.ID.ToUpperInvariant() == choice.ID.ToUpperInvariant());
            if (found != null)
            {
                found.Qty = choice.Qty;
            }

        }

    }
}
