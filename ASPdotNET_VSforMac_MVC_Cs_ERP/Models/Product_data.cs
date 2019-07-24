using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Models
{
    public class Product_data
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int SupplyId { get; set; }
        public virtual Supply Supply { get; set; }

        public int Product_itemId { get; set; }
        public virtual Product_item Product_item { get; set; }

        [Required]
        [MaxLength(100)]
        public string Unit_quality { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Stock_quality { get; set; }

        [Required]
        public decimal Order_quality { get; set; }

        [Required]
        public decimal Safe_quality { get; set; }

        public DateTime Createdate { get; set; }

        public virtual ICollection<Order_detail> Order_datails { get; set; }
    }
}
