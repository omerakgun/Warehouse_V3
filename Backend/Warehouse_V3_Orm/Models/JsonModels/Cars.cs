using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse_V3_Orm.Models
{
    public class Cars
    {
        public string Location { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
