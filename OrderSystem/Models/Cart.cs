using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Models
{
    public class Cart
    {
        private List<CartItems> order;

        public Cart()
        {
            order = new List<CartItems>();
        }

        public void AddItem(Items choice)
        {
            CartItems found = order.FirstOrDefault(p => p.Name.ToUpperInvariant() == choice.Name.ToUpperInvariant());
            if (found != null)
            {
                found.Qty++; 
            }
            else 
            {
                order.Add(new CartItems() { Name = choice.Name, Price = choice.Price, Qty = 1 });
            }

        }
        
        public double CalcTotal()
        {
            return order.Sum(p => p.Price * p.Qty);
        }

        //Test the below code
        public void RemoveItem(Items choice)
        {
            CartItems found = order.FirstOrDefault(p => p.Name.ToUpperInvariant() == choice.Name.ToUpperInvariant());
            if (found != null)
            {
                found.Qty--; 
                if (found.Qty <= 0)
                {
                    order.Remove(found);
                }
            }
            else 
            {
                ;
            }

        }
    }
}
