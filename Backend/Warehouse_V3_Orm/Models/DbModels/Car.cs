using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Warehouse_V3_Orm.Models
{
    [Table("CAR", Schema = "dbo")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Car Id")]
        public int CarID { get; set; }

        [Required]
        [Column("MAKE",TypeName ="varchar(30)")]
        [Display(Name = "MAKE")]
        public string Make{ get; set; }

        [Required]
        [Column("MODEL",TypeName = "varchar(100)")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Column("YEAR_MODEL",TypeName = "smallint")]
        public int YearModel { get; set; }

        [Column("PRICE", TypeName = "float")]
        public double Price { get; set; }

        [Column("LICENSED", TypeName = "bit")]
        public bool Licensed { get; set; }

        [Column("DATE_ADDED")]
        public DateTime DateAdded { get; set; }

    }
}
