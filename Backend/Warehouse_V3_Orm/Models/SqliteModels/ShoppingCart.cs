using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Warehouse_V3_Orm.Models.SqliteModels
{
    public class ShoppingCart
    {
        [Key]
        public string ID { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }
    }
}
