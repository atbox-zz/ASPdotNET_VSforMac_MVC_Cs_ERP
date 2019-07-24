using System;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.Models
{
    public class Order_master
    {
        [Key]
        public int Id { get; set; }

        public int CustomId { get; set; }
        public virtual Custom Custom { get; set; }

        [Required]
        public DateTime Orderdate { get; set; }

        [Required]
        public DateTime Deliverydate { get; set; }

        public int DeliverId { get; set; }
        public virtual Deliver Deliver { get; set; }

        [Required]
        public decimal Charges { get; set; }

        [Required]
        [MaxLength(100)]
        public string Receiver { get; set; }

        [Required]
        [MaxLength(300)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string Postcode { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime Createdate { get; set; }
    }
}
