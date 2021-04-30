using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA2_OrderSystem.Models;

namespace CA2_OrderSystem.Models
{
    public class ItemsContext : DbContext
    {
        public DbSet<Items> Items { get; set; }

        private const string connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=Cart1.mdb;Trusted_Connection=False;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }

        public DbSet<CA2_OrderSystem.Models.CartItems> CartItems { get; set; }

        public DbSet<CA2_OrderSystem.Models.Cart> Cart { get; set; }
    }
}
