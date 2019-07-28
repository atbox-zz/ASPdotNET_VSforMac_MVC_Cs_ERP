using System;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "部門名稱不得為空白")]
        [Display(Name = "部門名稱")]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime Createdate { get; set; }
    }
}
