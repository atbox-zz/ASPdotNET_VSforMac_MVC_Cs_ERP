using System;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels
{
    public class TitleViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "職稱名稱")]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime Createdate { get; set; }
    }
}
