using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Warehouse_V3_Orm.Models
{
    public partial class WarehouseDBContext : DbContext
    {
        private SqlServerInfo serverInfo;
        public WarehouseDBContext()
        {
            if (serverInfo == null)
            {
                serverInfo = JObject.Parse(File.ReadAllText("sqlconfig.json")).ToObject<SqlServerInfo>();
            }
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Initial Catalog=Warehouse_V3;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        //public DbSet<Car> Cars { get; set; }
    }
}
