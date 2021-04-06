using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderSystem.Models;

namespace OrderSystem.Models
{
    public class CartContext : DbContext
    {
            public DbSet<Items> Items { get; set; }

            private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Cart.mdb;Trusted_Connection=False;";

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(connectionString);

            }

            public DbSet<OrderSystem.Models.CartItems> CartItems { get; set; }
    }
}
