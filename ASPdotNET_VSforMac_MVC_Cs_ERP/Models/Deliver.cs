using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Models
{
    public class Deliver
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Contact_person { get; set; }

        [Required]
        [MaxLength(100)]
        public string Telphone { get; set; }

        public DateTime Createdate { get; set; }

        public virtual ICollection<Order_master> Order_masters { get; set; }
    }
}
