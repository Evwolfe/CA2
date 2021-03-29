﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Models
{
    public class StockContext : DbContext
    {
        private const string connectionString =
            "Server=(localdb)\\mssqllocaldb;DataBase=Stock;Trusted_Connection=False;";


        public DbSet<StockDetails> Stock { get; set; }

        //The below tells the system to use the connection string we entered above - directing it to the db
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString);
        }
    }
}
