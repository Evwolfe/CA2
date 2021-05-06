using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA2_OrderSystem.Models;

namespace CA2_OrderSystem.Models
{
    public class StockContext : DbContext
    {
        public DbSet<Stock> Stock { get; set; }

        //private const string connectionString = "Server=(localdb)\\mssqllocaldb;DataBase=Stock1;Trusted_Connection=False;";

        private const string connectionString = "Server=tcp:stephenca2.database.windows.net,1433;Initial Catalog=StockSystem;Persist Security Info=False;User ID=ad;Password=Kingdom2Hearts;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    //The below tells the system to use the connection string we entered above - directing it to the db
    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString);
        }

        //The below tells the system to use the connection string we entered above - directing it to the db
        public DbSet<CA2_OrderSystem.Models.Items> Items { get; set; }

        //The below tells the system to use the connection string we entered above - directing it to the db
        public DbSet<CA2_OrderSystem.Models.CartItems> CartItems { get; set; }
    }
}
