using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse_V3_Orm.Models
{
    public class Vehicle
    {
        [JsonProperty("_id")]
        public int CarID { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("year_model")]
        public int YearModel { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("licensed")]
        public bool Licensed { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }
    }
}
