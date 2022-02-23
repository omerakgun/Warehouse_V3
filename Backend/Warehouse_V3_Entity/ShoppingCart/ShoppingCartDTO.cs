using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse_V3_Entity.ShoppingCart
{
    public class ShoppingCartDTO
    {
        public string ID { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Location { get; set; }
        public Location WarehouseLocation { get; set; }
        public int YearModel { get; set; }
        public double Price { get; set; }
        public bool Licensed { get; set; }
        public string DateAdded { get; set; }
    }
}
