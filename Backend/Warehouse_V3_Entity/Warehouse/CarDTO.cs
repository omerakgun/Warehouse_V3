using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse_V3_Entity
{
    public class CarDTO
    {
        public int CarID { get; set; }
        public int WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public Location WarehouseLocation { get; set; }
        public string Location { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int YearModel { get; set; }

        public double Price { get; set; }

        public bool Licensed { get; set; }

        public string DateAdded { get; set; }
    }
}
