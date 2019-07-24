using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Models
{
    public class Title
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime Createdate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Custom> Customs { get; set; }

        public virtual ICollection<Supply> Supplys { get; set; }
    }
}
