﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Models
{
    public class Custom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Contact_person { get; set; }

        public int TitleId { get; set; }
        public virtual Title Title { get; set; }

        [Required]
        [MaxLength(300)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string Postcode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Telphone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Fax { get; set; }

        public DateTime Createdate { get; set; }

        public virtual ICollection<Order_master> Order_masters { get; set; }
    }
}
