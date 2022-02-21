using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse_V3_Orm.Models
{
    public class Warehouse
    {
        [JsonProperty("_id")]
        public int ID { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public Cars Cars { get; set; }
    }
}
