using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA2_OrderSystem.Models
{
    public class OrdersContext : DbContext
    {
        private const string connectionString =
           "Server=(localdb)\\mssqllocaldb;DataBase=Orders1;Trusted_Connection=True;";


        public DbSet<Orders> OrderDetails { get; set; }

        //The below tells the system to use the connection string we entered above - directing it to the db
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString);
        }
    }
}
