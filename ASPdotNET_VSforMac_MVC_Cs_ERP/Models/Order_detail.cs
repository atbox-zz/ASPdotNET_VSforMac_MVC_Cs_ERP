using System;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Models
{
    public class Order_detail
    {
        [Key]
        public int Id { get; set; }

        public int Order_masterId { get; set; }
        public virtual Order_master Order_master { get; set; }

        public int Product_dataId { get; set; }
        public virtual Product_data Product_data { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Quality { get; set; }

        public DateTime Createdate { get; set; }
    }
}
