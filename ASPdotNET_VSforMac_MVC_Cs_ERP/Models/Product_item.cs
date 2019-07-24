using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Models
{
    public class Product_item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Descripcition { get; set; }

        public DateTime Createdate { get; set; }

        public virtual ICollection<Product_data> Product_datas { get; set; }
    }
}
