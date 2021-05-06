using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA2_OrderSystem.Models
{
    public class OrdersContext : DbContext
    {
        //private const string connectionString ="Server=(localdb)\\mssqllocaldb;DataBase=Orders6;Trusted_Connection=True;";

        private const string connectionString = "Server=tcp:stephenca2.database.windows.net,1433;Initial Catalog=Orders;Persist Security Info=False;User ID=ad;Password=Kingdom2Hearts;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DbSet<Orders> OrderDetails { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString);
        }
    }
}
