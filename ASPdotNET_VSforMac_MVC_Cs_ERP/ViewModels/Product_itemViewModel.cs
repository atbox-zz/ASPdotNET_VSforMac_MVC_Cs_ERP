using System;
using System.ComponentModel.DataAnnotations;

namespace ASPdotNET_VSforMac_MVC_Cs_ERP.ViewModels
{
    public class Product_itemViewModel
    {
        [Display(Name = "類別編號")]
        public int Id { get; set; }

        [Required(ErrorMessage = "類別名稱不可為空白")]
        [MaxLength(100, ErrorMessage = "不可超過100個字元")]
        [Display(Name = "類別名稱")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "不可超過500個字元")]
        [Display(Name = "說明")]
        public string Descripcition { get; set; }

        [Display(Name = "建立時間")]
        public DateTime Createdate { get; set; }
    }
}
