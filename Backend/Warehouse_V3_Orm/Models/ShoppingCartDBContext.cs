using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Warehouse_V3_Orm.Models.SqliteModels;
using Microsoft.Data.Sqlite;

namespace Warehouse_V3_Orm.Models
{
    public class ShoppingCartDBContext : DbContext
    {
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public ShoppingCartDBContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=Warehouse_V3.db";
            optionsBuilder.UseSqlite(connectionString);            
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
